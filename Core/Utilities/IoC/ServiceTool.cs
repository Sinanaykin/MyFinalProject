using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)//.NET İN SERVİSLERİNİ AL VE ONLARI BUİLD ET DEMEK.Web api ve autofac de olusturdugumuz injecktion ları olusturabilmemize yarıyor bu kod.
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
