using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]//Bu attribute ü classlara ,metodlara ekleyebilirsin birden fazla ekleyebilirsin ve inherite edilen yerlerde de bu attribute çalıssın demek
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }//hangi attribute önce calısssın onu sıralarız burda

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
