using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BuiltInMiddlewareDemo.Models;
using BuiltInMiddlewareDemo.Repository;
using Microsoft.Extensions.Configuration;

namespace BuiltInMiddlewareDemo.Controllers
{
    public class HomeController : Controller
    {
        private IDataManager dm;
       // private IConfiguration configuration;
        public HomeController(IDataManager dataManger /*IConfiguration config*/)
        {
            this.dm = dataManger;
           // this.configuration = config;

        }

        public IActionResult Index([FromServices]IConfiguration configuration)
        {
            // throw new IndexOutOfRangeException("Some Custom error...");
            ViewBag.Message = dm.GetData();
            ViewBag.UserName = configuration.GetValue<string>("UserDetails:Name");
            ViewBag.Age = configuration.GetValue<string>("UserDetails:Age");
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
