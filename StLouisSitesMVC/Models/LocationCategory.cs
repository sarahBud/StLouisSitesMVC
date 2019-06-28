using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSitesMVC.Models
{
    public class LocationCategory
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }  
        public Location Location { get; set; }
    }
}
