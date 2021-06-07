
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;


namespace Core.Extensions
{
    public static class ClaimExtensions//Extension genişletmek demek.
    {
        public static void AddEmail(this ICollection<Claim> claims, string email)//Burda mesela AddEmail metodu ICollection<Claim> içine eklenicek demek bu. parametreside email.JwtHelper içinde mesela artık claims.AddEmail diyip ekleme yapabilicez
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
}
