using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface IProductDal
    {
        List<Product> GetAll();
        void Add(Product product);//Product göndeririz dısarıdan
        void Update(Product product);
        void Delete(Product product);
        List<Product> GetAllByCategory(int categoryId); //ürünleri categorye göre filtreler.Dısarıdan bir categoryId göndeririz.Yani Arayüzden categorye basınca ürünler gelicek onun için olan metod

    }
}
