using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal //IProductDal ı da eklemeliyiz çünkü producta ait özel metodları eklersek burda implemente etmeliyiz
    {
        public List<ProductDetailDto> GetProductDetail()
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var result = from p in context.Products //Products tablomuza p dedik
                             join c in context.Categories//Categories tablomuza c dedik 
                             on p.CategoryId equals c.CategoryId//Products ın CategoryId si ile Categories in CategoryId si üzerinden işlem yapıcaz
                             select new ProductDetailDto//hangi kolonları istiyoruz onu belirticez.ProductDetailDto da tanımlı olan kolonlar gelsin demek
                             {
                                 ProductId = p.ProductId,//ProductId yi Products içindeki ProductId den al 
                                 ProductName = p.ProductName,//ProductName yi Products içindeki ProductName den al 
                                 CategoryName = c.CategoryName,//CategoryName yi Categories içindeki CategoryName den al 
                                 UnitsInStock = p.UnitsInStock//UnitsInStock yi Products içindeki UnitsInStock den al 
                             };
                return result.ToList();//sonucu liste olarak döndür
            }
        }
    }
}
