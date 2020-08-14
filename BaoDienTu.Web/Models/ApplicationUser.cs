using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BaoDienTu.Web.Models
{
    public class ApplicationUser:IdentityUser
    {
        public bool Gender { get; set; }
        public DateTime DoB { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        [DataType(DataType.Date)]
        public string FullName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
