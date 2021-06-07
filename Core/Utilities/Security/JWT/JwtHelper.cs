using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.JWT
{
   public class JwtHelper:ITokenHelper
    {
        public IConfiguration Configuration { get; }//Configuration appsetting deki değerleri okumamıza yarar
        private TokenOptions _tokenOptions;//configuration sınıfı ile appsettings de okudugum değerleri atacağım nesnedir TokenOptions
        private DateTime _accessTokenExpiration;//AccessToken nezaman geçersizleşicek
        public JwtHelper(IConfiguration configuration)//ctor
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();//configuration la appsettings e git ordaki TokenOptions değerlerini  burdaki _tokenOptions ata
            
        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);//token süresi suan dan itibaren _tokenOptions daki süre  .token options da configuration ile appsettingdeki süre alınır 
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);//securityKey alıyoruz burda oluşturup
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);//hangi algoritmayı ve anahtarı  kulkanıcak onu veriyoruz
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);//aşağıda metod yaptık  CreateJwtSecurityToken için.tokenOption ,user ,signingCredentials,operationClaims bilgileri veriyoruz)
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, 
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(//yeni token olusturmaya yarıyor
                issuer:tokenOptions.Issuer,//issuer,audience,expires ...  bilgilerini oluşturuyoruz
                audience:tokenOptions.Audience,
                expires:_accessTokenExpiration,
                notBefore:DateTime.Now,
                claims: SetClaims(user,operationClaims),//claimler(yetkiler ve daha fazlası) için aşağıda bir metod var
                signingCredentials:signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();//ClaimExtensions sınıfı sayesinde bu şekilde ekleme yapabiliyoruz
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);//mail ekliyorum.ClaimExtensions sınıfı sayesinde bu şekilde ekleme yapabiliyoruz
            claims.AddName($"{user.FirstName} {user.LastName}");//İki tane stringi yan yana yazar bu
            claims.AddRoles(operationClaims.Select(c=>c.Name).ToArray());//role ekliyorum
            
            return claims;
        }
    }
}