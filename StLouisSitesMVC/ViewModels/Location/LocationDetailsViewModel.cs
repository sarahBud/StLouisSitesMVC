using StLouisSitesMVC.Data;
using StLouisSitesMVC.ViewModels.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSitesMVC.ViewModels.Location
{
    public class LocationDetailsViewModel
    {
        private ApplicationDbContext context;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ReviewDetailsViewModel> ReviewDetailsViewModels { get; set; }

        public static LocationDetailsViewModel GetLocationDetailsViewModel(ApplicationDbContext context, int id)
        {
            LocationDetailsViewModel locationDetailsViewModel = new LocationDetailsViewModel();
            
            Models.Location location = context.Locations
                .Single(l => l.Id == id);

            List<Models.Review> reviews = context.Reviews
            .Where(r => r.LocationID == id)
            .ToList();

            List<ReviewDetailsViewModel> reviewDetailsViewModels = new List<ReviewDetailsViewModel>();
            foreach (Models.Review review in reviews)
            {
                ReviewDetailsViewModel reviewDetailsViewModel = new ReviewDetailsViewModel();
                reviewDetailsViewModel.Rating = review.Rating;
                reviewDetailsViewModel.Comment = review.Comment;
                reviewDetailsViewModels.Add(reviewDetailsViewModel);

            }

            return new LocationDetailsViewModel()
            {
                Name = location.Name,
                Description = location.Description,
                Id = location.Id,
                ReviewDetailsViewModels = reviewDetailsViewModels
            };
        }
    }
}
