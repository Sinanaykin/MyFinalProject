using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidations;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]//Add metodunu ProductValidator u kullanarak doğrula demek bu
        public IResult Add(Product product)//Geri dönüş değerini voidden IResult message döndürücek artık çünkü
        {

            //İş kodları

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);//Geri dönüş değerini voidden IResult yaptık bu yüzden bişeyleri geri döndürmeliyiz burda geriye Result dönücek .Burda SuccessResult zaten true döner birdaha onu belirtmeye gerek yok istersek burdaki gibi message verebiliriz vermesekde olur.
            //(Sürekli kullanıcağımız mesajları Business altındaki Constants içindeki Messages clasına toplayabiliriz burdaki gibi.Business içine yazmamızın sebebi evrensel değil Product sadece bu projeye özel ondan Core a yazmadık)
        }

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

        public IDataResult<List<Product>> GetAllByCategory(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));//Product içindeki CategoryId eşitse bizim gönderdiğimiz id onları filtrele demek.Burda sadece data ve success(true ) döner.
            //IProductDal içinde tekrar bu metodtan oluturmaya gerek yok GetAll a filtre vererek yapabiliriz bunu
        }

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
    }
}
