using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
      

        public Result(bool success, string message):this(success)//burda Ctor olusturucaz.Hem success hem message dönsün istiyoruz.:this(success) demek bu Result çalısınca tek parametreli Ctor olan Resultda çalıssın demek
        {
            Message = message; //Message yerine göndericeğimiz message gelir

            //Kısacası 2 parametre gönderirsek bu Result çalısıcak tek parametre(message olmadan) gönderirsek aşağıdaki çalışıcak
        }
        public Result(bool success)//Burda mesaj döndürmek istemiyoruz sadece success dönsün
        {
            
            Success = success; //Success yerine göndericeğimiz success gelir.
            
        }


        public bool Success { get; }

        public string Message { get; }
    }
}
