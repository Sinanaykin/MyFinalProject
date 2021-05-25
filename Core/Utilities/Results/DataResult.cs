using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>//HEM Resulttan kalıtım aldık hem IDataResult dan implemente edicez.DataResult Result ı içeriyor demek yani message ve succes de dönücek bu yüzden Result dan kalıtım aldık
    {
        public DataResult(T data,bool success,string message):base(success,message)//Aynı Result daki gibi tek fark burda geri dönüş değeri oldugunda data ekledik
        {
            Data = data;
        }
        public DataResult(T data, bool success):base(success)//message göndermek istemezse bu kullanılır
        {
            Data = data;
        }
        public T Data { get; }
    }
}
