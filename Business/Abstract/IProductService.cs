using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IProductService
    {
        IDataResult<List<Product>> GetAll();//burası eskiden List<Product> bu şekilde liste dönüyodu şimdi hem sonuç hem liste dönücek.IDataResult daki T burda List<Product> mesela.
        IDataResult<List<Product>>  GetAllByCategory(int id);//Category ye göre filterereleme yapmak için bir kategory id si göndermeliyiz
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);//Fiyata göre sıralama mesela şu fiyat aralığında olan ürünleri getir dicez ondan 2 tane fiyat yollamalıyız min ve max olarak
        IDataResult<List<ProductDetailDto>> GetProductDetail();//Mesela burda geriye bir dto ve success ile message da döner
        IDataResult<Product> GetById(int productId); //Gönderdiğimiz productId ye göre ürün döndürür.Burda geri döünş değeri Product tek bir ürün döner bu yüzden IDataResult daki T miz burda Product oldu
        IResult Add(Product product);//bursı önceden void di ama artık bir sonuc dönücek bu yüzden IResult yaptık
    }
}
