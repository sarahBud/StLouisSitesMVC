using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSitesMVC.Models
{
    public class Location : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string County { get; set; }

        public IList<Review> Reviews { get; set; }
        public IList<LocationCategory> LocationCategories { get; set; }
       
        

    }
}
