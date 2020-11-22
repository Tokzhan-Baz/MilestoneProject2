using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneProject2.Models
{
    public class Projects
    {
        public int Id { get; set; }
        public String Poster { get; set; }
        public String Title { get; set; }
        public String Text { get; set; }



        public ICollection<News> News { get; set; }
    }
}
