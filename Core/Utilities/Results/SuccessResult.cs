using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Basarılı sonuc için True yu default olarak veriyoruz kısaca
   public class SuccessResult: Result//inheritance yaptık
    {
        public SuccessResult(string message) : base(true, message)//ctor.Base ye yani Result a success ve message göndericez.SuccessResult in içine sadece message yazdık çünkü zaten Başarılı sonuc yani true oldugunu biliyoruz
        {

        }
        public SuccessResult():base(true)//eğer SuccessResult a parametre vermezsek base(Result) e true gönderir otomatik .
        {

        }
    }
}
