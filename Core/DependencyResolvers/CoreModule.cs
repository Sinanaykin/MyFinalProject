using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule 
    {
        public void Load(IServiceCollection serviceCollection)//Uygulama seviyesinde service bağımlılıklarını çözümleyeceğimiz yer olacak
        {
           serviceCollection.AddMemoryCache();// MemoryCacheManager deki IMemoryCache memoryCache; yapısını çözmemiz için bunu da ekliyoruz.bunu ekleyince orda otomatik injection yapıyo ctor yapmıyoruz bidaha.Arka planda IMemoryCache in instance ını olusturuyor bizim için
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//biri bizden IHttpContextAccessor  isterse  HttpContextAccessor bunu ver.IHttpContextAccessor de ctrl nokta bas install local versiyon yükle
           serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();//biri bizden ICacheManager  isterse  MemoryCacheManager bunu ver.Microsoftun kendi implementasyonu. 
            serviceCollection.AddSingleton<Stopwatch>();

        }
    }
}
