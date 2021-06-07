using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public  interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);//Token üretecek mekanızma bu.Bunu User için olustur diyoruz  VE  hangi claimleri(yetkileri koyalım ) diyoruz OperaationClaim listesindeki  koyalım demek buda
      
        //Mesela kullanıcı adını ve sifresini giriyor.eğer doğruysa ilgili kullancı için  veritabanından yetkileri bulucak orda bir tane Json web token üreticek ve ona göre sistemde ilerleyebilicek kullanıcı
    
    }
}
