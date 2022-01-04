using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidations;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;//Bir Manager içine başka bir Manager enjekte edemeyiz bu yüzden kullanmak istediğimiz managerin servisini enjekte ettik
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        //[SecuredOperation("product.add,admin")]//Ürün ekleme işlemini sadece admin yapabilir demek bu
        [ValidationAspect(typeof(ProductValidator))]//Add metodunu ProductValidator u kullanarak doğrula demek bu
        [CacheRemoveAspect("IProductService.Get")]//Ürün ekleyince IProductService deki  bütün Get leri siler .IProductService dedik çünkü hepsi ona bağlı.
        public IResult Add(Product product)//Geri dönüş değerini voidden IResult message döndürücek artık çünkü
        {
            //Yarın öbür gün yeni kural gelirse kuralı en altta oluştur virgül diyip buraya(BusinessRules.Run içine) ekle işlem tamam.
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId), CheckIfProductNameExists(product.ProductName),CheckIfCategoryLimitExceded());//BusinessRules içindeki Run metoduna altta tanımladığımız iş kuralllarını gönderiyoruz burda.result tek bir sonuç döner bize
           
            if (result!=null)//kurala uymayan bir durum varsa
            {
                return result;//result döner hata mesajı mesela
            }
         
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);//Geri dönüş değerini voidden IResult yaptık bu yüzden bişeyleri geri döndürmeliyiz burda geriye Result dönücek .Burda SuccessResult zaten true döner birdaha onu belirtmeye gerek yok istersek burdaki gibi message verebiliriz vermesekde olur.
           //(Sürekli kullanıcağımız mesajları Business altındaki Constants içindeki Messages clasına toplayabiliriz burdaki gibi.Business içine yazmamızın sebebi evrensel değil Product sadece bu projeye özel ondan Core a yazmadık)
           



        }
        
        [CacheAspect]//Getaall daha önceden çağırılmışsa tekrar database den almaz veriyi cache den alır
        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları
            //mesela yetkisi varsa ürünleri alsın dicez.
            //if (DateTime.Now.Hour == 13)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MainTenanceTime);//hata mesajı burda data dönmez zaten hata var sadece succes(false) ve message döner
            //}
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(),Messages.ProductsListed);//Burda eskiden return _productDal.GetAll() dı. şimdi Geriye hem ürünler hem succcess(true default olarak SuccesDataResult uldugu için) hem message döndürür o yüzden böyle
        }

        public IDataResult<List<Product>> GetAllByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == categoryId));//Product içindeki CategoryId eşitse bizim gönderdiğimiz id onları filtrele demek.Burda sadece data ve success(true ) döner.
            //IProductDal içinde tekrar bu metodtan oluturmaya gerek yok GetAll a filtre vererek yapabiliriz bunu
        }

        [CacheAspect]
       //[PerformanceAspect(10)]//metodun çalışması 5 saniyeyi geçerse beni uyar dicez.Hata vermesin diye kapattık şimdilik
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product> (_productDal.Get(p => p.ProductId == productId));//data ve success(true ) döner burdada
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));//Bizim göndereceğimiz ifyat aralığında olan lar filtrelenir.Geriye data ve success(true döner),message vermek istemedik
            //IProductDal içinde tekrar bu metodtan oluturmaya gerek yok GetAll a filtre vererek yapabiliriz bunu
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetail()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetail());//ProductName ve CategoryName aynı anda alabilmek için Dto(Join işlemleri) yaptık.burdada data ve success(true) döner geriye
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]//Ürün güncelleyince IProductService deki  bütün Getleri siler .IProductService dedik çünkü hepsi ona bağlı.
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }


        //İŞ KURALLARINI BURDA METOD OLARAK OLUŞTURUP YUKRDA KULLANIYORUZ AMA PRİVATE OLMALI SADECE BU CLASS İÇİNDE KULLANILMALIDIR.
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId) //Kategorideki ürün sayısının kurallara uygunluğunu doğrula demek.ve categoryId göndermeliyiz
        {

            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;//Seçilen kategorideki ürün sayısını öğrenebiliriz bu şekilde.Product içindeki CategoryId si gönderdiğimiz categoryId ye eşit olanların sayısını aldık
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError); //ürün sayısı 15 den  büyükse hata mesajı döner.Messages ın içinde tanımlı bu hata mesajı
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName) //Bu ürün ismi daha önce eklendimi kontrol et .ve productName  göndermeliyiz
        {

            var result = _productDal.GetAll(p => p.ProductName == productName).Any();//Gönderdiğimiz productName isminde hiç isim varmı git bak deriz.Any  filtrelemeye uyan kayıt var mı demek
            if (result==true)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists); //Böyle bir isim zaten var diye hata alır Messages ın içinde tanımlı bu hata mesajı
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();//bütün category bilgilerini al.Burda Bir Manager içine başka bir Manager enjekte edemeyiz bu yüzden kullanmak istediğimiz managerin servisini enjekte ettik yukarda burda onu kullanıdk
            if (result.Data.Count>15)//Category sayısı 15 den büyükse
            {
                return new ErrorResult(Messages.CategoryLimitExceded); //limit aşıldı diye mesaj döndür
            }
            return new SuccessResult();//
        }
        
        //[TransactionScopeAspect]//bunuda kapadık hata vermesin diye
        public IResult AddTransactionalTest(Product product)
        {
            //Add(product);
            //if (product.UnitPrice<10)
            //{
            //    throw new Exception("");
            //}
            //Add(product);
            //return null;
            _productDal.Update(product);
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
