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

        [Required(ErrorMessage ="Description must be between 2 and 300 characters")]
        [MinLength(3)]
        [MaxLength(300)]
        public string Description { get; set; }
        public string Address { get; set; }
        public string County { get; private set; }

        public static int CreateLocation(ApplicationDbContext context, LocationCreateViewModel locationViewModel)
        {
            Models.Location location = new Models.Location();
            {
                location.Name = locationViewModel.Name;
                location.Description = locationViewModel.Description;
                location.Address = locationViewModel.Address;
                location.County = locationViewModel.County;
            }
            context.Add(location);
            context.SaveChanges();

            return location.Id;


        }



    }
}
