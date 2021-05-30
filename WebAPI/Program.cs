using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())//.Net core in kendi IOC yapılanmasını değilde AutofacBusinessModule yapısını kullanmasını söylemeliyiz.Servis sağlayıcısı fabrikası olarak AutofacServiceProviderFactory ' i kullandiyoruz burda
                //AutofacServiceProviderFactory  ampule bas install package den install latest version sec ve yükle
                .ConfigureContainer<ContainerBuilder>(builder=>
                {
                    builder.RegisterModule(new AutofacBusinessModule());//Burdada .net core un kendi IOC containeri yerine Autofac kullanıcaz ama onun için yazdıgımız dosyayı da burda belirtiyoruz
                })
            .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
