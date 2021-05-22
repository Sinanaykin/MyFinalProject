using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProductDetailDto : IDto //Aynı IEntity mantıgındaki gibi  boş class kalmaması için bunuda IDto dan türetiyoruz
    //ProductDetailDto gibi bir Dto kullanmamızın sebebi biz mesela Product yanında CategoryName ini yazdırmak istiyoruz ama
    //Product Entities 'inin içinde CategoryName yok sadece CategoryId var  bu yüzden join yapmamız lazım
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnitsInStock { get; set; }
    }

}