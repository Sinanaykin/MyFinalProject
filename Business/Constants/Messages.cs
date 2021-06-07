using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants//Constant sabit demek aynı mesajları sürekli tekrar tekrar yazmamak için yapıyoruz bunu.Business içine yazmamızın sebebi evrensel değil Product sadece bu projeye özel ondan Core a yazmadık)
{
   public static class Messages //static veriyoruz .sabit çünkü new lememek için static verdik.Temel mesajlarımızı bunu içine yazıyoruz tekrar tekrar aynı mesajları yazmamak için
    {
        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductNameInValid = "Ürün ismi geçersiz";
        public static string MainTenanceTime="Sistem bakımda";
        public static string ProductsListed="Ürünler listelendi";
        public static string ProductCountOfCategoryError="Bir Kategori de en fazla  10 ürün olabilir";
        public static string ProductNameAlreadyExists="Bu isimde zaten başka bir ürün var";
        public static string CategoryLimitExceded="Kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public static string AuthorizationDenied="Yekiniz yok";
        public static string UserRegistered="Kayıt oldu";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string PasswordError="Şifre hatalı";
        public static string UserAlreadyExists="Kullanıcı mevcut";
        public static string AccessTokenCreated="Token oluşturuldu";
        public static string SuccessfulLogin="Başarılı giriş";
    }
}
