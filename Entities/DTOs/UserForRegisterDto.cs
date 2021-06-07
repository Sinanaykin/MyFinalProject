using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserForRegisterDto : IDto
    {
        public string Email { get; set; }//kayıt içinde email password firstname lastname gerekli
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}