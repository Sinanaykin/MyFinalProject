﻿using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();//bunu ekle using Microsoft.Extensions.DependencyInjection;
        }

        protected override void OnSuccess(IInvocation invocation)//metod basarılı olursa ekleme silme güncelleme işlemleri basarılı gerçekleşirse Cache imi sil demek bu
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}