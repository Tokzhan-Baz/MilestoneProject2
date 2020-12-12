using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneProject2.Models
{
    public class Startups
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Photo url")]
        public String  Poster { get; set; }

        [StringLength(50, ErrorMessage = "Text length should be less than 50")]
        [Required]
        public String Texts { get; set; }
        [Required]
        public String Country { get; set; }

       
        [Required]
        public String AboutProject { get; set; }
        public IList<StartupsNews> StartupsNews { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (this.Country == "123" || this.AboutProject == "123")
                errors.Add(new ValidationResult("Incorrect input "));

            return errors;
        }
    }
}
