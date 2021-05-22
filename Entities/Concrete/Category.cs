using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
     //çıplak class kalmasın bu yüzden Entities altındaki abstract a intercface ekledik IEntity adında.Daha sonra IEntity 'i burda implemente ettik.IEntity demek bizim için bu bir veri tabanı nesnesidir demek
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
