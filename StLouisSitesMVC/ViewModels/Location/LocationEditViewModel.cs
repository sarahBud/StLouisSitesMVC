using StLouisSitesMVC.Data;
using StLouisSitesMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSitesMVC.ViewModels.Location
{
    public class LocationEditViewModel
    {
        private ApplicationDbContext context;
        public int Id { get; set; }
        [Required(ErrorMessage ="You must enter a location name!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description must be between 2 and 200 characters.")]
        [MinLength(2)]
        [MaxLength(200)]
        public string Description { get; set; }
        [Required(ErrorMessage ="Please enter an address!")]
        public string Address { get; set; }
        [Required(ErrorMessage ="You must select a county!")]
        public string County { get; set; }
        public List<int> CategoryIds { get; set; }
        public List<LocationCategoriesCreateViewModel> Categories { get; set; }

        public LocationEditViewModel() { }

        public LocationEditViewModel(int id, ApplicationDbContext context)
        {

            Models.Location location = context.Locations.
                Single(l => l.Id == id);

            Name = location.Name;
            Description = location.Description;
            Address = location.Address;
            County = location.County;

            this.Categories = context.Categories.Select(category => new LocationCategoriesCreateViewModel
            {
                CategoryName = category.CategoryName,
                Id = category.Id

            }).ToList();

        }

        //public LocationEditViewModel(int id, ApplicationDbContext context)
        //{
        //    this.Categories = context.Categories.Select(category => new LocationCategoriesCreateViewModel
        //    {
        //        CategoryName = category.CategoryName,
        //        Id = category.Id

        //    }).ToList();
        //}

        public void Persist(int id, ApplicationDbContext context)
        {
            Models.Location location = new Models.Location()
            {
                Id = id,
                Name = this.Name,
                Description = this.Description,
                Address = this.Address,
                County = this.County
            };
            context.Update(location);
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
