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
        private Models.Location m;

        public LocationListItemViewModel(Models.Location m)
        {
            this.m = m;
        }

        public static List<LocationListItemViewModel> GetLocations(ApplicationDbContext context)
        {
            return context.Locations
                //.Include(m => m.Ratings)
                
                .Select(m => new LocationListItemViewModel(m))
                .ToList();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public double AverageRating { get; set; }
       

     

        }
    }

