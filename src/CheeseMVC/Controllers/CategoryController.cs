﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;

namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CheeseDbContext context;

        public CategoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            List<CheeseCategory> cheeseCategories = context.Categories.ToList();

            return View(cheeseCategories);
        }
        public IActionResult Add()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();
            return View(addCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                CheeseCategory newCheeseCategory = new CheeseCategory
                {
                    Name = addCategoryViewModel.Name,
                };
                context.Categories.Add(newCheeseCategory);
                context.SaveChanges();

                return Redirect("/Category");
            }
            return View(addCategoryViewModel);
        }
    }
}

    
    

