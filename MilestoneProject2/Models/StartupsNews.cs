using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneProject2.Models
{
    public class StartupsNews
    {
        public int StartupsId { get; set; }
        public Startups Startups { get; set; }

        public int NewsId { get; set; }
        public News News { get; set; }
    }
}
