using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule 
    {
        public void Load(IServiceCollection serviceCollection)//Uygulama seviyesinde service bağımlılıklarını çözümleyeceğimiz yer olacak
        {
           serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//biri bizden IHttpContextAccessor  isterse  HttpContextAccessor bunu ver.IHttpContextAccessor de ctrl nokta bas install local versiyon yükle
        }
    }
}
