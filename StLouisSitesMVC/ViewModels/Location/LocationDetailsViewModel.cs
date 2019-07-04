using StLouisSitesMVC.Data;
using StLouisSitesMVC.ViewModels.Review;
using StLouisSitesMVC.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StLouisSitesMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace StLouisSitesMVC.ViewModels.Location
{
    public class LocationDetailsViewModel
    {
        private ApplicationDbContext context;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<LocationCategory> LocationCategories { get; set;}
        public List<ReviewDetailsViewModel> ReviewDetailsViewModels { get; set; }
        public List<CategoryDetailsViewModel> CategoryDetailsViewModels { get; set; }
        //public string CategoryNames { get; set; }

        public static LocationDetailsViewModel GetLocationDetailsViewModel(ApplicationDbContext context, int locationId)
        {
            LocationDetailsViewModel locationDetailsViewModel = new LocationDetailsViewModel();

            Models.Location location = context.Locations
                .Include(l => l.LocationCategories)
                .FirstOrDefault(l => l.Id == locationId);


            List<Models.Review> reviews = context.Reviews
            .Where(r => r.LocationID == locationId)
            .ToList();

            var selectedCategories = context.LocationCategories
                .Where(locationCategory => locationCategory.LocationId == locationId)
                .ToList();

            List<Category> categories = context.Categories
            .ToList();
            
            selectedCategories.ForEach(selectedCategory => 
                selectedCategory.Category = categories.Single(category => 
                    category.Id == selectedCategory.CategoryId
                )
            );



            //IList<Models.LocationCategory> categories = location.LocationCategories;

            IList<ReviewDetailsViewModel> reviewDetailsViewModels = new List<ReviewDetailsViewModel>();
            foreach (Models.Review review in reviews)
            {
                ReviewDetailsViewModel reviewDetailsViewModel = new ReviewDetailsViewModel();
                reviewDetailsViewModel.Rating = review.Rating;
                reviewDetailsViewModel.Comment = review.Comment;
                reviewDetailsViewModels.Add(reviewDetailsViewModel);

            }



            List<CategoryDetailsViewModel> categoryDetailsViewModels = new List<CategoryDetailsViewModel>();
            foreach (Models.LocationCategory selectedCategory in selectedCategories)
            {
                CategoryDetailsViewModel categoryDetailsViewModel = new CategoryDetailsViewModel();
                categoryDetailsViewModel.Name = selectedCategory.Category.CategoryName;
                categoryDetailsViewModels.Add(categoryDetailsViewModel);

            }

            return new LocationDetailsViewModel()
            {
                Name = location.Name,
                Description = location.Description,
                Id = location.Id,
                ReviewDetailsViewModels = reviewDetailsViewModels.ToList(),
                CategoryDetailsViewModels = categoryDetailsViewModels.ToList()
            };
        }
    }
}
