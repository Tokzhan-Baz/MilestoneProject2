using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneProject2.Models
{
    public class Startups
    {
        public int Id { get; set; }

        public String  Poster { get; set; }

        public String Texts { get; set; }

        public String Country { get; set; }

        public String AboutProject { get; set; }
        public IList<StartupsNews> StartupsNews { get; set; }
    }
}
