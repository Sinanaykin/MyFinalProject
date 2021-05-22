
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //çıplak class kalmasın bu yüzden Entities altındaki abstract a intercface ekledik IEntity adında.IEntity demek bizim için bu bir veri tabanı nesnesidir demek
    //IEntity i implemente eden class(Yani Product, Category gibi) bir veritabanı tablosu olduğunu belirtir.
    public class Product:IEntity
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; } //int ' in bir küçüğü shorttur
        public decimal UnitPrice { get; set; }
    }
}
