using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllByCategory(int id);//Category ye göre filterereleme yapmak için bir kategory id si göndermeliyiz
        List<Product> GetByUnitPrice(decimal min, decimal max);//Fiyata göre sıralama mesela şu fiyat aralığında olan ürünleri getir dicez ondan 2 tane fiyat yollamalıyız min ve max olarak
        List<ProductDetailDto> GetProductDetail();
    }
}
