using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
             ProductTest();//Product ile ilgili denemeleri metord haline getirdik
            //CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());//InMemory dan EntityFramework yapısına geçmek için InMemoryProductDal yerine EfProductDal yazarız sadece

            //foreach (var product in productManager.GetAllByCategory(2))//kategoriye göre filtreleme yapabiliriz
            //{
            //    Console.WriteLine(product.ProductName);
            //}

            foreach (var product in productManager.GetProductDetail())//Join işlemi yaptık ondan artık ProductName ve CategoryName beraber gelebiliyor
            {
                Console.WriteLine(product.ProductName + "/" +product.CategoryName);
            }
        }
    }
}
