using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneProject2.Models
{
    public class RegisterViewModel
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Company { get; set; }

        public string PhoneNumber { get; set; }
   
        public string Password { get; set; }

        public string PasswordConfirm { get; set; }
    }
}
