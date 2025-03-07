﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProtozoaColonies.Models;

namespace ProtozoaColonies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void TEST()
        {
            Models.PitriDish Dish = new Models.PitriDish();
            Dish.NewDish(10);
            Dish.PlaceCell(5, 2, "111111");
            Dish.PlaceCell(4, 2, "222222");
            Dish.PlaceCell(6, 2, "333333");
            Dish.CheckDish();
            Dish.ShareDish();
        }
    }
}
