using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidations
{
  public class ProductValidator:AbstractValidator<Product>//Product için doğrulama yapıcaz ondan böyle.AbstrackValidator den türeticez.
    {
        public ProductValidator()//kuralları bunun(ctor un) içine yazıcaz
        {
            RuleFor(p => p.ProductName).NotEmpty();//ProductName boş olamaz
            RuleFor(p=>p.ProductName).MinimumLength(2);//Product ın ProductName en az 2 karakter olmalı dedik
            RuleFor(p => p.UnitPrice).NotEmpty();//UnitPrice alanı boş olamaz
            RuleFor(p => p.UnitPrice).GreaterThan(0);//UnitPrice 0 dan büyük olmalı
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);//CategotyId 1 e eşit  oldugu zaman(Meseka içecek kategorisi ise) UnitPrice 10 dan büyük ve eşit olmalı
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile baslamalıdır");//ProductName A ile başlamalı olmayan metodu olustururuz asağıda.Burda messageda ekleyebiliriz.
        }

        private bool StartWithA(string arg)  //A İLE BASLAMASI İÇİN GEREKEN RULE YAZDIK METOD İLE    
        {
            return arg.StartsWith("A");
        }
    }
}
