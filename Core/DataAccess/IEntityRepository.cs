using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //generic constraint:KISITLAMA
    //clas:referans tipi
    //IEntity:IEntity veya IEntity den implemente olan bir şey olmalıdır .
    //new :new lenebilir olmalı
    //BU 3 KISITLAMAYI EKLEYİNCE ARTIK T VERİ TABANI NESNELERİ İLE ÇALISAN BİR REPOSİTORY OLDU
    public interface IEntityRepository<T> where T:class,IEntity,new()  //T bir referans tipi olmalı , T IEntity veya IEntity den implemente olan bir şey olmalıdır , T new lenebilir olmalı (mesela interface olmaz).
      
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);//bu yapıyla birlikte kategoriye göre getir ,ürün fiyatına göre getir gibi ayrı ayrı metodlar yazmamıza gerek kalmaz.Burda filtre vermeyebilirsin
        //filtre vermezsek tüm data gelir filtre verirsek filtreye göre data gelir demek

        //GetAll metodunu bu formatta yazınca Business de olusturacagımız GetAllByCategory,GetByUnitPrice gibi metotdları DataAcces de tekrar oluşturmamıza gerek kalmaz zaten GetAll karşılar bunları
        
        T Get(Expression<Func<T, bool>> filter ); // tek bir ürün gelmesi için.tek bir ürünün detayına gitmek için.
        void Add(T entity);//Product göndeririz dısarıdan T yerine Product ,entity yerine product yazıyoduk önceden ama GENERİC REPOSİTORY PATTERN KULLANDIK BİZ.
        void Update(T entity);
        void Delete(T entity);

        //List<T> GetAllByCategory(int categoryId); //ürünleri categorye göre filtreler.Dısarıdan bir categoryId göndeririz.Yani Arayüzden categorye basınca ürünler gelicek onun için olan metod
        //YUKARIDA Expression<Func<T, bool>> filter=NULL  YAPISINI KULLANDIK ARTIK BU METODA İHTİYAC KALMADI zaten yukarıda categorye göre filtreleme yapabiliriz.
    }
}
