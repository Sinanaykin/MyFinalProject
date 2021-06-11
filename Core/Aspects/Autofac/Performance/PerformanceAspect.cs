using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwatch;//birtane timer koyduk metod nekadar sürücek.StopWatch ın instance sini Core module ekledik (Yolunu yani)

        public PerformanceAspect(int interval)
        {
            _interval = interval;//bu intervalin mantıgıda productmanagerde böyle kullanım sunuyo mesela [PerformanceAspect(5)] dersek bu metodun kullanımı 5 sn yi geçerse beni uyar diyebiliyoruz
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }


        protected override void OnBefore(IInvocation invocation)//metotdan önce kronometreyi baslatıyorum
        {
            _stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)//metot bittiğindede
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)//o ana kadar geçen süreyi hesaplıyorum mesela geçen süre 5 den büyükse
            {
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");//consolo log olarak gelir
            }
            _stopwatch.Reset();
        }
    }
}
