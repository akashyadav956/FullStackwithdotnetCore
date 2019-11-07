using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConfigurationDemo.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ConfigurationDemo.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration configuration;
        private AppConfiguration appConfig;
        private ProjectDetails projectDetails;
        public HomeController(IConfiguration config, IOptions<AppConfiguration> options, IOptions<ProjectDetails> projectOption)
        {
            this.configuration = config;
            this.appConfig = options.Value;
            this.projectDetails = projectOption.Value;
        }
        public IActionResult Index()
        {
            //var company = configuration.GetValue<string>("CompanyName");
            //var location = configuration.GetValue<string>("Location");
            //var count = configuration.GetValue<int>("ParticipantCount");
            //var arch = configuration.GetValue<string>("PROCESSOR_ARCHITECTURE");
            //var noOfProcessor = configuration.GetValue<int>("NUMBER_OF_PROCESSORS");

            //var title = configuration.GetValue<string>("ProjectDetails:Title");
            //var duration = configuration.GetValue<string>("ProjectDetails:Duration");

            //var projectDetails = configuration.GetSection("ProjectDetails");

            //var durations = projectDetails["Duration"];
            //var status = projectDetails["Status"];

            ViewBag.CompanyName = appConfig.CompanyName;
            ViewBag.Location = appConfig.Location;
            ViewBag.Participants = appConfig.ParticipantCount;
            ViewBag.arch = appConfig.PROCESSOR_ARCHITECTURE;
            ViewBag.noOfPro = appConfig.NUMBER_OF_PROCESSORS;
            ViewBag.Project = appConfig.ProjectDetails;
           
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
