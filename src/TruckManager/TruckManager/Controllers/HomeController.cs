using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TruckManager.Models;
using CCALearn.TruckLib;

namespace TruckManager.Controllers
{
    public class HomeController : Controller
    {
        private TruckRepository _truckRepo = new TruckRepository();  // @1:07

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            var myTruck = new Pickup
            {
                Year = 2012,
                Manuf = "Ford",
                Capacity = 2
            };

            _truckRepo.Add(myTruck);

            return View(myTruck);
        }
        [Authorize]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
