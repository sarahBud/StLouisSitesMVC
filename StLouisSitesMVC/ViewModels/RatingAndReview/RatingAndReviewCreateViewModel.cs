using Microsoft.AspNetCore.Mvc.Rendering;
using StLouisSitesMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSitesMVC.ViewModels.RatingAndReview
{
    public class RatingAndReviewCreateViewModel
    {
        private string ratings = "12345";

        [Required]
        public int Id { get; set; }
        [Required]
        public string LocationName { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public SelectList Ratings { get { return GetRatings(); } }

        private SelectList GetRatings()
        {
            var ratingSelectListItems = ratings.Select(r => new SelectListItem(r.ToString(), r.ToString()));
            return new SelectList(ratingSelectListItems);
        }

        internal void Persist(ApplicationDbContext context)
        {
            Models.Review rating = new Models.Review
            {
                Id = this.Id,
                Rating = this.Rating
            };
            context.Add(rating);
            context.SaveChanges();
        }
    }
}
