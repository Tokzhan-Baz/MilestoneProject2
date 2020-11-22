using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneProject2.Models
{
    public class NewsN
    {

        public int Id { get; set; }
      
        public string Title { get; set; }
        
        public string Number { get; set; }

        //One-to-One
        public int NewsId { get; set; }
        public News News { get; set; }
    }
}
