using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //Aspect=Metodun basında, sonunda, hata verince çalışacak yapı biz nerede çalıssın dersek orda çalısır mesela Validation için  OnBefore yazarız çünkü kontrol işlemlerin başında olsun isteriz.
    {
        private Type _validatorType;//Bana bir ValidatorType ver diyoruz
        public ValidationAspect(Type validatorType)//Bana ValidatorType ı ver diyo.Yani mesela ProductValidator
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))//Eğer verilen ValidatorType değilse
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil"); //hata ver diyo
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//Reflections bu.Çalışma anında birşeyleri İNSTANCE OLUSTURUR( new ler).Yani ProductValidator u new le diyo
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//Validatorun base type ını bul  Generiğindeki çalışma tipini(Mesela Product) bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//oradaki metodun parametrelerini gez entitytype(Product) eşitse al
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);//Validation daki validate metoduna  mesela ProductValidator ve Product ı ver diyo
            }
        }
    }
}
