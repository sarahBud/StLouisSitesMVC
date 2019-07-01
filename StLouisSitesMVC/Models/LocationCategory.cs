using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSitesMVC.Models
{
    public class LocationCategory
    {
        public int Id { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }  
        public Location Location { get; set; }
    }
}
