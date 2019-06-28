using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StLouisSitesMVC.Data;
using StLouisSitesMVC.Models;
using StLouisSitesMVC.ViewModels.Category;

namespace StLouisSitesMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext context;

        public CategoryController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Category> categories = context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            CategoryCreateViewModel categoryCreateViewModel = new CategoryCreateViewModel();
            return View(categoryCreateViewModel);
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateViewModel categoryCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                Category newCategory = new Category
                {
                    CategoryName = categoryCreateViewModel.Name
                };

                context.Categories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/Category");
            }
            return View(categoryCreateViewModel);
        }

    }
}