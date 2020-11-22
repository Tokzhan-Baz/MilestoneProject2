using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneProject2.Models
{
    public class News
    {
        public int Id { get; set; }

        public String Title { get; set; }

        public String Information { get; set; }
        public DateTime Time { get; set; }

        //One-to-Many
        public int ProjectsId { get; set; }
        public Projects Projects { get; set; }

        //One-to-One
        public NewsN NewsN { get; set; }

        //Many-to-Many
        public IList<StartupsNews> StartupsNews { get; set; }
    }
}
