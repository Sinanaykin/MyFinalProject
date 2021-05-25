using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Bunu sadece void  yani geri göünüşü olmayan lar için kullanıcaz
   public interface IResult
    {
        bool Success { get; } //sadece okunabilir ondan get olucak.Bu bize basarılı veya başarısız döndürür 
        string Message { get; }//Buda mesajı döndürür mesela ürün eklendi
    } 
}
