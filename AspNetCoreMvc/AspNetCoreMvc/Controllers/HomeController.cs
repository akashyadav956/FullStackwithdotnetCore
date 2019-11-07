using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreMvc.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using AspNetCoreMvc.services;

namespace AspNetCoreMvc.Controllers
{
    public class HomeController : Controller
    {
        IMemoryCache cache;
        IDistributedCache dCache;
        DataService _ds;
        public HomeController(IMemoryCache cache, IDistributedCache distCache, DataService ds)
        {
            this.cache = cache;
            this.dCache = distCache;
            this._ds = ds;
        }

        public IActionResult Index()
        {
            _ds.Message = "This is DI demo";
            var data = cache.Get<DateTime?>("now");
            if (data == null)
            {
                data = DateTime.Now;
                cache.Set<DateTime?>("now",data, DateTimeOffset.Now.AddMinutes(3));
            }
            ViewBag.LoadingTime = data;


            var cacheData = dCache.GetString("users");
            if (string.IsNullOrEmpty(cacheData))
            {
                Dictionary<int, string> mydata = new Dictionary<int, string>
                {
                { 101,"akash"},
                { 102,"anurag"},
                { 103,"aman"}
               };


                dCache.SetString("users", JsonConvert.SerializeObject(mydata), new DistributedCacheEntryOptions {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5)
                });
                ViewBag.Users = mydata;
                ViewBag.Source = "Loaded Initially";
            }
            else {
                ViewBag.Users = JsonConvert.DeserializeObject<Dictionary<int, string>>(cacheData);
                ViewBag.Source = "Loaded from caches";
            }
            

            return View();
        }

        public IActionResult Privacy()
        {
            if ((bool)HttpContext.Items["IsVerified"])
            {
                ViewBag.Message = "Request data is valid";
            }
            else {
                ViewBag.Message = "Request data is invalid";
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
