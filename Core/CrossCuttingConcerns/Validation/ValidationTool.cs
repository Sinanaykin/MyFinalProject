using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
  public static  class ValidationTool 
    {
        public static void Validate(IValidator validator,object entity)//ampulden IValidator ü yükle use local version 9.5.1 secip.buraya entity dto herşey ekleyebiliriz  object entity yazıyoruz
        {
            var context = new ValidationContext<object>(entity);//object=Product,entity=product
           
            var result = validator.Validate(context);//validator(productValidator mesela)kullanarak contexti (product) ı doğrula demek
            if (!result.IsValid)//eğer sonuc geçerli değilse hata verir
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
