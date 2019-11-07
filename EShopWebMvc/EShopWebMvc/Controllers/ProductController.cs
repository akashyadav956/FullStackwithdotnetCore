using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShopWebMvc.Infrastructure;
using EShopWebMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace EShopWebMvc.Controllers
{
   [Route("products")]
    public class ProductController : Controller
    {
        private ShopDbContext  sdb;
        private readonly int PageSize = 3;
         

        public ProductController(ShopDbContext  shopDbContext)
        {
            this.sdb = shopDbContext;
        }

        [HttpGet]
        public IActionResult Index(int currentPage =1)
        {
            ViewBag.PageCount = (int)Math.Ceiling((sdb.Products.Count() / (decimal)PageSize));
            ViewBag.CurrentPage = currentPage;
            var produts = GetPagedProduct(currentPage);
            return View(produts);
        }

        [NonAction]
        private IEnumerable<Product> GetPagedProduct(int pageNo)
        {
          return sdb.Products
                .Include(p=>p.Category)
                .Skip(PageSize * (pageNo - 1)).Take(PageSize);
        }


        [HttpGet("add", Name = "AddProduct")]
        public IActionResult AddProduct()
        {
            ViewBag.Categories = sdb.Categories.ToList();
            return View();
        }

        [HttpPost("add", Name = "AddProduct")]
        public async Task<IActionResult> AddProductAsync(Product product)
        {
            if (ModelState.IsValid)
            {
                sdb.Products.AddAsync(product);
                sdb.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else {
                ViewBag.Categories = sdb.Products
                .Include(p => p.Category)
                .ToList();
                return View(product);
            }
         
        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var product = sdb.Products.Find(id);
            if (product != null)
            {
                ViewBag.Categories = sdb.Categories.ToList();
                return View(product);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> EditAsync(Product product)
        {
            if (ModelState.IsValid)
            {
                sdb.Entry<Product>(product).State = EntityState.Modified;
                await sdb.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else {
                ViewBag.Categories = sdb.Products
               .Include(p => p.Category)
               .ToList();
                return View("Edit",product);
            }
        }
    }
}