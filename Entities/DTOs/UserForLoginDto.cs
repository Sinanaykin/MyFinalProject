using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }//Login olucak kişiden Email ve password isteriz
        public string Password { get; set; }
    }
}
