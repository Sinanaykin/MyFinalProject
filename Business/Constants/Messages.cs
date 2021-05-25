using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants//Constant sabit demek aynı mesajları sürekli tekrar tekrar yazmamak için yapıyoruz bunu.Business içine yazmamızın sebebi evrensel değil Product sadece bu projeye özel ondan Core a yazmadık)
{
   public static class Messages //static veriyoruz .sabit çünkü new lememek için static verdik.Temel mesajlarımızı bunu içine yazıyoruz tekrar tekrar aynı mesajları yazmamak için
    {
        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductNameInValid = "Ürün ismi geçersiz";
        public static string MainTenanceTime="Sistem bakımda";
        public static string ProductsListed="Ürünler listelendi";
    }
}
