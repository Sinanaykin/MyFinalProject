using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
   public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data,string message):base(data,true,message)//buda geri dönüşü olanların default olarak true dönen hali
        {

        }
        public SuccessDataResult(T data):base(data,true)//burda message göndermek istemezse kullanırız
        {

        }
        public SuccessDataResult(string message):base(default,true,message)//datayı default haliyle kullanmak için,successimiz true,message 
        {

        }
        public SuccessDataResult():base(default,true)//burdada message yok, datamız default,successimiz true
        {
                
        }
    }
}
