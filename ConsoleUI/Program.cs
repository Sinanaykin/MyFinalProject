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
            ProductManager productManager = new ProductManager(new EfProductDal());//InMemory dan EntityFramework yapısına geçmek için InMemoryProductDal yerine EfProductDal yazarız sadece

            //foreach (var product in productManager.GetAllByCategory(2))//kategoriye göre filtreleme yapabiliriz
            //{
            //    Console.WriteLine(product.ProductName);
            //}

            foreach (var product in productManager.GetByUnitPrice(50,100))//fiyata göre filtreleme yapabiliriz
            {
                Console.WriteLine(product.ProductName);
            }

        }    
    }
}
