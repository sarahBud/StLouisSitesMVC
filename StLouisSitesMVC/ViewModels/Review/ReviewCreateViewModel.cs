using Microsoft.AspNetCore.Mvc.Rendering;
using StLouisSitesMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSitesMVC.ViewModels.Review
{
    public class ReviewCreateViewModel
    {

        private ApplicationDbContext context;

        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public static int GetReviewViewModel(ApplicationDbContext context, ReviewCreateViewModel reviewCreateViewModel)
        {
           
            Models.Review review = new Models.Review();
            review.LocationID = reviewCreateViewModel.LocationID;
            review.Rating = reviewCreateViewModel.Rating;
            review.Comment = reviewCreateViewModel.Comment;
           
            context.Add(review);
            context.SaveChanges();
            return review.Id;
        }
    }
}
