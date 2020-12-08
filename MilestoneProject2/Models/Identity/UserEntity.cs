using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneProject2.Models.Identity
{
    public class UserEntity : IdentityUser
    {
        public UserEntity()
        {
        }

        public string Name { get; set; }
        public string SurName { get; set; }
     
    }
}
