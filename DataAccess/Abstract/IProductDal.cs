using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface IProductDal:IEntityRepository<Product> //IProductDal a  sen bir IEntityRepository sin çalışma şeklin ise Product diyoruz Yada IProductDal ı IEntityRepository den türetiyoruz T yerine Product yazıyoruz diyebiliriz.
    {
     

    }
}
