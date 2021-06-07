using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);//claimleri almak için metod
        void Add(User user); //kullanıcı ekler
        User GetByMail(string email);//maile göre kullanıcı getitir
    }
}
