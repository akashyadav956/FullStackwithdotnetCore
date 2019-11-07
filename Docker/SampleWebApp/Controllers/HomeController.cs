using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SampleWebApp.Models;

namespace SampleWebApp.Controllers
 {

   
    public class HomeController : Controller
    {
          IConfiguration configuration;
        public HomeController(IConfiguration config){

            this.configuration= config;
        }
        public IActionResult Index()
        {
            ViewBag.Username = configuration.GetValue<string>("Name");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
