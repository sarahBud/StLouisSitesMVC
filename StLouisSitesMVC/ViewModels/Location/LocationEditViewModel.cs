using StLouisSitesMVC.Data;
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
        [Required(ErrorMessage ="Please enter a location name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description must be between 2 and 200 characters.")]
        [MinLength(2)]
        [MaxLength(200)]
        public string Description { get; set; }
        [Required(ErrorMessage ="Please enter an address")]
        public string Address { get; set; }
        [Required]
        public string County { get; set; }

        public LocationEditViewModel() { }

        public LocationEditViewModel(int id, ApplicationDbContext context)
        {

            Models.Location location = context.Locations.
                Single(l => l.Id == id);

            Name = location.Name;
            Description = location.Description;
            Address = location.Address;
            County = location.County;

        }


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
            context.SaveChanges();

        }
    }
}
