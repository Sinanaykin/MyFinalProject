using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
   public class ErrorResult:Result//inheritance yaptık
    {
        //Başarısız sonuc için False u default olarak veriyoruz kısaca
        public ErrorResult(string message) : base(false, message)//ctor.Base ye yani Result a success ve message göndericez.ErrorResult in içine sadece message yazdık çünkü zaten başarısız sonuc yani false oldugunu biliyoruz
        {

        }
        public ErrorResult() : base(false)//eğer ErrorResult a parametre vermezsek base(Result) e false gönderir otomatik .
        {

        }
    }
}
