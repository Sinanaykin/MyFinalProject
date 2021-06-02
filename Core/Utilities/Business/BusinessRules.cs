using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
   public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)//params lullanırsak metoda istediğimiz kadar IResult(İş kuralı) yollarız.logics iş kuralları için oluşturduğumuz metod lar
        {
            foreach (var logic in logics)//her bir logics kuralını gez
            {
                if (!logic.Success)
                {
                    return logic;//başarısızza logic döndürür.Yani kurala uymayanı döndürür
                }
            }
            return null;//başarılı ise bişey döndürmesine gerek yok
        }
    }
}
