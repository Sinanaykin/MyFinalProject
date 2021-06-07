using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
   public class AccessToken//erişim anahtarı denir
    {
        public string Token { get; set; }//token bilgisi için bu
        public DateTime Expiration { get; set; } //bitiş zamanını veririz
    }
}
