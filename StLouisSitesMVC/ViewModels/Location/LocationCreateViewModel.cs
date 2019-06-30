using Microsoft.AspNetCore.Mvc.Rendering;
using StLouisSitesMVC.Data;
using StLouisSitesMVC.Models;
using StLouisSitesMVC.ViewModels.Categories;
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
        [MinLength(2)]
        [MaxLength(300)]
        public string Description { get; set; }
        [Required(ErrorMessage ="Enter an address!")]
        public string Address { get; set; }
        [Required(ErrorMessage ="You must select a county!")]
        public string County { get; set; }
        public List<int> CategoryIds { get; set; }
        public List<LocationCategoriesCreateViewModel> Categories { get; set; }
       

        //public static int CreateLocation(ApplicationDbContext context, LocationCreateViewModel locationViewModel)
        //{
        //    Models.Location location = new Models.Location();
        //    {
        //        location.Name = locationViewModel.Name;
        //        location.Description = locationViewModel.Description;
        //        location.Address = locationViewModel.Address;
        //        location.County = locationViewModel.County;
        //    }
        //    context.Add(location);

        //    context.SaveChanges();

        //    return location.Id;


        //}

        public LocationCreateViewModel() { }

        public LocationCreateViewModel(ApplicationDbContext context)
        {
            List<int> CategoryIds = new List<int>();

            this.Categories = context.Categories.Select(category => new LocationCategoriesCreateViewModel {
                CategoryName = category.CategoryName,
                Id = category.Id

            }).ToList();
        }

        public void Persist(ApplicationDbContext context)
        {
            Models.Location location = new Models.Location
            {
                Name = this.Name,
                Description = this.Description,
                Address = this.Address,
                County = this.County,
                
            };
            context.Locations.Add(location);
            List<LocationCategory> locationCategories = CreateManyToManyRelationships(location.Id);
            location.LocationCategories = locationCategories;
            context.SaveChanges();
        }

        private List<LocationCategory> CreateManyToManyRelationships(int locationId)
        {
            return Categories.Where(cat => cat.Selected)
                .Select(cat => new LocationCategory { LocationId = locationId, CategoryId = cat.Id }).ToList();
        }


    }
}
