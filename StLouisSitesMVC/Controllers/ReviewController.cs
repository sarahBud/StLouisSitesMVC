using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StLouisSitesMVC.Data;
using StLouisSitesMVC.Models;
using StLouisSitesMVC.ViewModels.RatingAndReview;

namespace StLouisSitesMVC.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ApplicationDbContext context;

        public ReviewController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Review> ratings = context.Reviews.ToList();
            return View(ratings);
        }


        public IActionResult Create(int? id)
        {
            ViewData["LocationCreate"] = context.Locations.SingleOrDefault(M => M.Id == id);
            return View(); ;
        }

        [HttpPost]
        public IActionResult Create(int Id, RatingAndReviewCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Persist(context);
            return RedirectToAction(controllerName: "Location", actionName: "Index");
        }

    }
}