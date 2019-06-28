using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSitesMVC.ViewModels.Category
{
    public class CategoryCreateViewModel
    {
        [Required(ErrorMessage = "You must enter a category!!!")]
        public string Name { get; set; }
    }
}
