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

        public static LocationDetailsViewModel GetLocationDetailsViewModel(ApplicationDbContext context, int id)
        {
            LocationDetailsViewModel locationDetailsViewModel = new LocationDetailsViewModel();

            Models.Location location = context.Locations
                //.Include(l => l.LocationCategories)
                .FirstOrDefault(l => l.Id == id);


            List<Models.Review> reviews = context.Reviews
            .Where(r => r.LocationID == id)
            .ToList();

            //List<Models.LocationCategory> locationCategories = context.LocationCategories
            //.Where(r => r.LocationId == id)
            //.ToList();

            //IList<Models.LocationCategory> categories = location.LocationCategories;

            IList<ReviewDetailsViewModel> reviewDetailsViewModels = new List<ReviewDetailsViewModel>();
            foreach (Models.Review review in reviews)
            {
                ReviewDetailsViewModel reviewDetailsViewModel = new ReviewDetailsViewModel();
                reviewDetailsViewModel.Rating = review.Rating;
                reviewDetailsViewModel.Comment = review.Comment;
                reviewDetailsViewModels.Add(reviewDetailsViewModel);

            }



            //List<CategoryDetailsViewModel> categoryDetailsViewModels = new List<CategoryDetailsViewModel>();
            //foreach (Models.LocationCategory category in categories)
            //{
            //    CategoryDetailsViewModel categoryDetailsViewModel = new CategoryDetailsViewModel();
            //    categoryDetailsViewModel.Name = category.Category.CategoryName;
            //    categoryDetailsViewModels.Add(categoryDetailsViewModel);

            //}

            return new LocationDetailsViewModel()
            {
                Name = location.Name,
                Description = location.Description,
                Id = location.Id,
                ReviewDetailsViewModels = reviewDetailsViewModels.ToList(),
                //CategoryDetailsViewModels = categoryDetailsViewModels.ToList()
            };
        }
    }
}
