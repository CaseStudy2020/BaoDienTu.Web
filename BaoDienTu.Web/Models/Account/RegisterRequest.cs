using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaoDienTu.Web.Models.Account
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public bool Gender { get; set; }
        public DateTime DoB { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
    }
}
