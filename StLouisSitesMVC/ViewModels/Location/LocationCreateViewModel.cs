using Microsoft.AspNetCore.Mvc.Rendering;
using StLouisSitesMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSitesMVC.ViewModels.Location
{
    

    public class LocationCreateViewModel
    {
        [Required(ErrorMessage ="You must enter a name!!!")]
        public string Name { get; set; }
        [Required(ErrorMessage ="You must enter a description!!!")]
        public string Description { get; set; }
        public string Address { get; set; }
        


        
    }
}
