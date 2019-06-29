using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StLouisSitesMVC.Data;
using StLouisSitesMVC.Models;
using StLouisSitesMVC.ViewModels.Location;

namespace StLouisSitesMVC.Controllers
{
    public class LocationController : Controller
    {
        private ApplicationDbContext context;

        public LocationController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<LocationListItemViewModel> viewModelLocations = LocationListItemViewModel.GetLocationListItemViewModel(context);
            return View(viewModelLocations);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(LocationCreateViewModel locationViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(locationViewModel);
            }

            int ID = LocationCreateViewModel.CreateLocation(context, locationViewModel);

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Details(int id)
        {

            LocationDetailsViewModel locationDetailsViewModel = LocationDetailsViewModel.GetLocationDetailsViewModel(context, id);
            return View(locationDetailsViewModel);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(model: new LocationEditViewModel(id, context));
        }

        [HttpPost]
        public IActionResult Edit(LocationEditViewModel locationEditViewModel, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(new LocationEditViewModel());
            }
            locationEditViewModel.Persist(id, context);
            return RedirectToAction(actionName: nameof(Index));
        }

    }
}