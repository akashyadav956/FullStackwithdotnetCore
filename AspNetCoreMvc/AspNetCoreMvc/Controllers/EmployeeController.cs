using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreMvc.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AspNetCoreMvc.Controllers
{
    [Route("employee")]
    public class EmployeeController : Controller
    {
        DataService _ds;
        public EmployeeController(DataService ds) {
            this._ds = ds;
        }
        // GET: Employee
        [HttpGet("list",Name ="EmpList")]
        public ActionResult Index()
        {
            ViewBag.DIdata = this._ds.Message;
            string message = "This is the first message of session data";
            var data = Encoding.UTF8.GetBytes(message);
            HttpContext.Session.Set("message",data);
            return View();
        }


        // GET: Employee/Details/5
        [HttpGet("details", Name = "EmpDetails")]
        public IActionResult Details()
        {
           
            ViewBag.Message =  HttpContext.Session.GetString("message");
            return View();
        }



        [HttpGet("mypage")]
        public IActionResult MyPage()
        {
            TempData["SameInfo"] = "Here is my tempdata value";
            return RedirectToAction("mypage2");
        }

        [HttpGet("mypage2")]
        public IActionResult MyPage2()
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}