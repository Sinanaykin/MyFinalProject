using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)//süre vermezsek 60 dk cache de durur
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();//serviceTool kullanarak hangi CacheManager kullandıgımızı belirtiyoruz.using Microsoft.Extensions.DependencyInjection; bunu yukarı ekle
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");//methodumun ismini bulmaya çalısıyorum.ReflectedType.FullName=namespace mesela Busines.Concrete.IProductService demek.invocation.Method.Name=çalıştırdıgım metod ismi(Getall mesela)
            var arguments = invocation.Arguments.ToList();//metodun parametrelerini listeye cevir diyoruz
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";//key oluşturduk
            if (_cacheManager.IsAdd(key))//bellekte böyle bir cache anahtarı(key) var mı
            {
                invocation.ReturnValue = _cacheManager.Get(key);//var ise metodu hiç çalıştırmadan geri dön 
                return;
            }
            invocation.Proceed();//yok ise metodu devam ettir çalıştır.Metod çalışınca veritabanına gidicek datayı alıp getiricek
            _cacheManager.Add(key, invocation.ReturnValue, _duration);//datayı cache e ekliyoruz
        }
    }
}
