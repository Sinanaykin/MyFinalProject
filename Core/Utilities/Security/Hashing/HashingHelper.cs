using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
   public class HashingHelper//bundan sonra parola vs hashleme ihtiyacımız olursa bunu kullanmak için olusturduğumuz bir class.Hash oluşturmaya yarar ve doğrulamaya
    {
        public static void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)//Biz bir password vericez dışarı passwordHash ve passwordSalt cıkarıcak ,olusturucak demek bu
        {
            using (var hmac=new System.Security.Cryptography.HMACSHA512())//kullanacağımız yapı bu System.Security.Cryptography içindeki HMACSHA512 class ı.
            {
                passwordSalt = hmac.Key;//passwordSalt olusturmak  için hmac in Key ini kullanıyoruz
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//passwordHash oluşturmak için ise ComputeHash kullanıcaz ama ona password vermeliyiz .Ayrıca Encoding.UTF8.GetBytes ile de byte a ceviriyoruz
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash,  byte[] passwordSalt)// burda password(bu kullanıcanın sonradan girdiği parola biz doğrumu diye kontrol edicez),passwordHash ve passwordSalt ı biz vericez kontrol edilicek doğrulancak demek bu.passwordhash ve passwordsalt veritabanında olusan passwordhash ve passwordsalt  dir
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))//doğrulama yapacağımız için passwordSaltı vermeliyiz burda
            {
               var computedHash= passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//passwordHash oluşturmak için ise ComputeHash kullanıcaz ama ona password vermeliyiz .Ayrıca Encoding.UTF8.GetBytes ile de byte a ceviriyoruz.Burda passwordSalt veriyoruz onu atlama
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])//computedHash imin i ninci değeri eşit değildir veritabanından gönderilen passwordHash imin i  ninci değerine.Yani burda computedHash de passwordSalt eklediğimizi belirtiyoruz ve öyle kıyaslıyoruz aslında
                    {
                        return false; //false döner
                    }
                }

                return true;
            }
            
        }
    }
}
