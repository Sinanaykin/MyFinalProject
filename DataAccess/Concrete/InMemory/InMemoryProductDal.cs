using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal //şimdilik belllekte çalısıcaz Entityframwork ile sonra geçicez bu yüzden kodlar burda farklı olur
    {
        List<Product> _products;
        public InMemoryProductDal() //ctor yani new landiği anda ,uygulama çalıştıgı anda bellekte asağıdaki ürünler oluşur.Yani şuan database bağlamadığımız için,verileri sanki databaseden geliyormus gibi simule ediyoruz
        {
            _products = new List<Product>
            {
                new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
                new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);//FirstAllDefault da olur.//gönderilen ürün id sine sahip listedeki ürünü bul demek bu sorgu._products içindeki ProductId ile bizim göndereceğimiz ProductId eşit olanı al demek

            _products.Remove(productToDelete);//sonra gelen tek bir ürünü sil demek bu da.
            
        }

        public List<Product> GetAll()
        {
            return _products; //geri döüş değeri var liste dönücek bu yüzden return diyoruz
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
          return  _products.Where(p => p.CategoryId == categoryId).ToList();//_product içindeki CategoryId bizim gönderdiğimiz categorId ye eşitse ürünle listelenir.
        }

        public void Update(Product product) //burdaki product bizim gönderdiğimiz yani arayüzden gönderdiğimiz 
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);//gönderilen ürün id sine sahip listedeki ürünü bul demek bu sorgu
            productToUpdate.ProductName = product.ProductName; //gelen tek bir ürünün ProductName ini bizim göndereceğimiz product ın ProductName  ile aynı yap demek
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }
    }
}
