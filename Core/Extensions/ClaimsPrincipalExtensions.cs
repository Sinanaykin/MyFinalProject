using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions//Bir kişinin claimlerine erişmek için  gereken kodları burda yazıp 
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)//mesela claimsPrincipal.ClaimRoles diyince bize direk rolleri döndürür
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
