using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSitesMVC.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<LocationCategory> LocationCategories { get; set; }


        public bool CheckboxAnswer { get; set; }
    }
}
