using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;
using System.Linq;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        //Adapter Pattern=var olan bir sistemi(Microsoftun cache yapısı) kendi sistemimize uyarladık
        IMemoryCache _memoryCache;//microsoft un kendi interface i bu hazır var zaten.Bunu çözmemiz lazım ama ctor ile olmaz bu core modulede yolunu veriyoruz bunun serviceCollection.AddMemoryCache(); bu şekilde

        public MemoryCacheManager()//
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();//_memoryCache İ İNJECTİONLA ALMAMIZ GEREKİYOR.ServiceTool(Core -Utilities-IoC-ServiceTool) içinden . ctrl nokta gelmezse (using Microsoft.Extensions.DependencyInjection;) bunu elle ekle yukarı
        }

        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));//key value ve bellekten ucuracağımız süreyi veriyoruz 10 dk sonra ucurur
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);//memorycache içinden Get et key i döndür ama T yi yani türünü ver.
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key); //daha çok üsttekini kullanıcaz ama bunuda kullanabiliriz 
        }

        public bool IsAdd(string key)//bellekte böyle bir key değeri var mı
        {
            return _memoryCache.TryGetValue(key,out _);//sadece bellekte böyle bir key var mı ona bakıcaz datayı istemiyoruz ondan out _ yazdık
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        //Bu yapıyı bilemeyiz mantıgını anla yeter
        public void RemoveByPattern(string pattern)//verdiğimiz patterne göre silme işlemi yapıcak.Çalışma anında bellekten silmeye yarar reflection ile yaparız bunu.Mesela [CacheRemoveAspect("IProductService.Get")] IProductService.Get içerenleri uçur diyebiliriz.ProductManagerde Add metodunun üstüne bunu ekleyip
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);//Git belleğe bak EntriesCollection bul
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;//definationları _memoryCache olanları bul
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)//herbir cache elemanını gez
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();//cache lerden bu kurala uyanları al

            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);//uyanları bellekten sil
            }
        }
    }
}
