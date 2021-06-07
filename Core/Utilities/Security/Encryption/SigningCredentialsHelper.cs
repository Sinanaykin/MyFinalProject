using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
   public class SigningCredentialsHelper//İmzalama demek bu. Web APİ NİN KULLANABİLECEĞİ JWT  larının olusturulabilmesi için gerekli .Credential demek kullanıcının siteme girmesi için elinde olan bilgiler demek kullanıcı adı vs gibi giriş bilgileri
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)//KULLANICAĞIMIZ ANAHTARI YOLLUYORUZ BURDA.
        {
            return new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha512Signature);//KULLANICAĞIMIZ ANAHTARI VE HANGİ ALGORİTMAYI KULLANCAĞIMIZI VERİYORUZ burda
        }
    }
}
