using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
   public  class SecurityKeyHelper //İçerisinde  şifreleme olan sistemler de herşeyi byte array formatında vermeliyiz.Yani asp net web tokenın anlayacagı hale getirmeliyiz

    { 
        public static SecurityKey CreateSecurityKey(string securityKey)//SecurityKey(appsetting de yazdığımız var ya) döndüren bir SecurityKey oluşturmalıyız.securityKey göndermeliyiz burda
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));//byte a çevirme işlemi yapar securutyKeyi.aynı zamanda simetrik security anahtarı haline gtirmeye yarar
        }
   
    
    }
}
