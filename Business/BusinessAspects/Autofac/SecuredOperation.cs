using Business.Constants;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)//bana rolleri ver diyoruz
        {
            _roles = roles.Split(',');//araya virgül koyarsak array olarak bize gelsin diye böyle yaptık
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)//metodun önünde çalıştır diyoruz
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();//kullanıcın rollerini bul diyoruz
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))//eğer claim lerinde ilgili rol varsa  devam et
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);//ilgili rol yoksa yetkin yok diye mesaj ver
        }
    }
}
