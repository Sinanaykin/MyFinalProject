using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
   
        public class ErrorDataResult<T> : DataResult<T>
        {
            public ErrorDataResult(T data, string message) : base(data, false, message)//buda geri dönüşü olanların default olarak false dönen hali
        {

            }
            public ErrorDataResult(T data) : base(data, false)//burda message göndermek istemezse kullanırız
            {

            }
            public ErrorDataResult(string message) : base(default, false, message)//datayı default haliyle kullanmak için,successimiz false,message 
        {

            }
            public ErrorDataResult() : base(default, false)//burdada message yok, datamız default,successimiz false
        {

            }
        }
    
}
