using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
   public interface ICacheManager
    {
        T Get<T>(string key);//T herşey olabilir hangi tip de tuttugumuzu belirticez.Ben sana bir key vereyim sen bana bellekten o keye karşılık gelen datayı ver diyorum burda
        object Get(string key);//buda üsttekinin generic olmayan versiyonu ama tip dönüşü yapmamız lazım burda daha çok üsttekini kullanıcaz ama bunuda kullanabiliriz

        void Add(string key,object value,int duration);//bir tane key ,bir tane value bu herşey olabilir bu yüzden türü object ve süre(cache de ne kadar durucak) tutan bir duration olucak
        bool IsAdd(string key);//Cache de var mı böyle bir key değeri kontrolü yapan bir metod buda
        void Remove(string key);//bir key vericez Cache den ucurur mu diye
        void RemoveByPattern(string pattern);//Verdiğimiz patterne göre silme işlemi yapıcak.Mesela bası sonu önemli değil içinde Category olanlar sil gibi

    }
}
