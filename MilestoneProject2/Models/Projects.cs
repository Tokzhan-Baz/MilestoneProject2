using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneProject2.Models
{
    public class Projects
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Photo url")]
        public String Poster { get; set; }
        [Required]
        [Display(Name = "Title")]
        public String Title { get; set; }
        [Required]
        public String Text { get; set; }



        public ICollection<News> News { get; set; }
    }
}
