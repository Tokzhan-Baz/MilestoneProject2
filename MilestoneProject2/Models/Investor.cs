using MilestoneProject2.Models.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static MilestoneProject2.Controllers.InvestorsController;

namespace MilestoneProject2.Models
{
    public class Investor
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Photo url")]
        public String Poster { get; set; }
        [Required]
        [OnlyStringAttribute]       
        public String Name { get; set; }
        [Required]       
        public int budget { get; set; }
    }
}
