using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //IDataResult u Geri dönüş değeri olan için kullanıyoruz Liste olabilir tek bir ürün olabilir
    public interface IDataResult<T>:IResult//T burda her şey olabilir aynı zamanda success ve message da lazım bunun için IResult ın implemente etmeli
        
    {
        T Data { get; }//Mesela t Ürün veya ürünler vs olabilir
    }
}
