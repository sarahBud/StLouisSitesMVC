using Microsoft.EntityFrameworkCore;
using StLouisSitesMVC.Data;
using StLouisSitesMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSitesMVC.ViewModels.Location
{
    public class LocationListItemViewModel
    {
        public static List<LocationListItemViewModel> GetLocationListItemViewModel(ApplicationDbContext context)
        {
            List<Models.Location> locations = context.Locations
                .Include(l => l.Reviews)
                .ToList();


            List<LocationListItemViewModel> viewModelLocations = new List<LocationListItemViewModel>();
            foreach (Models.Location location in locations)
            {
                LocationListItemViewModel viewModel = new LocationListItemViewModel();
                viewModel.Id = location.Id;
                viewModel.Name = location.Name;
                viewModel.Description = location.Description;
                //viewModel.CategoryNames = GetCategoryNames(location, context);
                viewModel.Reviews = location.Reviews;
                viewModel.AverageRating = location.Reviews.Count > 0 ? Math.Round(location.Reviews.Average(x => x.Rating), 2).ToString() : "n/a";

                viewModelLocations.Add(viewModel);

            }
            return viewModelLocations;


        }

        //private static string GetCategoryNames(Models.Location location, ApplicationDbContext context)
        //{
        //    //List<string> categoryNames = location.LocationCategories
        //    //    .Select(lc => lc.Category)
        //    //    .Select(c => c.CategoryName)
        //    //    .ToList();

        //    List<int> categoryIds = location.LocationCategories.Select(lc => lc.CategoryId).ToList();
        //    List<Category> categories = context.Categories.Where(c => categoryIds.Contains(c.Id)).ToList();
        //    categoryNames = categories.Select(c => c.CategoryName).ToList();

        //    return String.Join(", ", categoryNames);
        //}

        private ApplicationDbContext context;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryNames { get; set; }
        public List<Models.Review> Reviews { get; set; }
        public string AverageRating { get; set; }




    }
    }

