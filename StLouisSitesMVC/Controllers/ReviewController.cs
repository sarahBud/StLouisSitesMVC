using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StLouisSitesMVC.Data;
using StLouisSitesMVC.Models;
using StLouisSitesMVC.ViewModels.Review;

namespace StLouisSitesMVC.Controllers
{
    public class ReviewController : Controller
    {
        private ApplicationDbContext context;

        public ReviewController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create(int locationID)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ReviewCreateViewModel reviewCreateViewModel)
        {
            int Id = ReviewCreateViewModel.GetReviewViewModel(context, reviewCreateViewModel);

            return RedirectToAction(controllerName: nameof(Location), actionName: nameof(Index));
        }

    }
}