using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICategoryService
    {
        List<Category> GetAll();//bütün kategoriler gelir
        Category GetById(int categoryId);//kategori ye göre filtreler

    }
}
