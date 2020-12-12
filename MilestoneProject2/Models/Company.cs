using MilestoneProject2.Models.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneProject2.Models
{
    public class Company
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Photo url")]
        public String Poster { get; set; }
        [NotContainsDigits]  //Custom attribues
        [Required]
        public String  Name { get; set; }
        [Required]
        public String text { get; set; }
}
}
