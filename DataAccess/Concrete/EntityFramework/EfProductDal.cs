using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
            //USİNG BİTTİĞİ ANDA nesneler garbage collector tarafından bellekten atılır.Using c# özel güzel bir yapı(IDisposable pattern implementation of c#).
        {     
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedentity = context.Entry(entity);//contexte bizim göndereceğimiz product(entity) yakala
                addedentity.State = EntityState.Added;//ilişkilendiidriğimiz yapıyı ekle demek bu
                context.SaveChanges();//değişiklikleri kaydet

            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var deletedentity = context.Entry(entity);//contexte bizim göndereceğimiz product(entity) yakala
                deletedentity.State = EntityState.Deleted;//ilişkilendiidriğimiz yapıyı sil demek bu
                context.SaveChanges();//değişiklikleri kaydet
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter) //tek data getirir
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);//contextdeki Product tablomuza yerleştik filtreye göre tek bir ürün getirir
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList(); //Eğer filter null eşitse(filtre vermemişse)  bize tüm tabloyu getir liste yap ,eğer null eşit değilse(filtre vermişse) filtre yap öyle tabloyu getir liste yapıp
                                      //context deki Product ta yerleş ve listele :contextdeki Product da yerleş filtrele ve listele
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedentity = context.Entry(entity);//contexte bizim göndereceğimiz product(entity) yakala
                updatedentity.State = EntityState.Modified;//ilişkilendiidriğimiz yapıyı güncelle demek bu
                context.SaveChanges();//değişiklikleri kaydet
            }
        }
    }
}
