﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneProject2.Models
{
    public class LoginViewModel
    {
        public string Email { get; set; }
      
        public string Password { get; set; }

        
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }



    }
}
