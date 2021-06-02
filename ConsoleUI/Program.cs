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
            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));//InMemory dan EntityFramework yapısına geçmek için InMemoryProductDal yerine EfProductDal yazarız sadece

            //foreach (var product in productManager.GetAllByCategory(2))//kategoriye göre filtreleme yapabiliriz
            //{
            //    Console.WriteLine(product.ProductName);,
            //}
            var result = productManager.GetProductDetail();
            if (result.Success == true)
            {
                foreach (var product in result.Data)//Join işlemi yaptık ondan artık ProductName ve CategoryName beraber gelebiliyor
                {
                    Console.WriteLine(product.ProductName + "/" + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
