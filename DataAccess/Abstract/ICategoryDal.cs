using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface ICategoryDal:IEntityRepository<Category>//ICategoryDal a  sen bir IEntityRepository sin çalışma şeklin ise Category diyoruz Yada ICategoryDal ı IEntityRepository den türetiyoruz T yerine Category yazıyoruz diyebiliriz.
    {
      
    }
}
