using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotTrends.Models;
using Microsoft.AspNetCore.Hosting;

namespace HotTrends.Areas.AdminArea.Controllers
{
    public class adminController : Controller
    {
        newssiteContext context = null;
        IHostingEnvironment env = null;
        public adminController(IHostingEnvironment _env, newssiteContext _context)
        {
            context = _context;
            env = _env;
        }
        [HttpGet]
        public IActionResult AddVideoPost()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddVideoPost(Videopost vp)
        {
            try
            {
                context.Videopost.Add(vp);
                context.SaveChanges();
                ViewBag.message = "Data inserted successfully";

            }
            catch
            {
                ViewBag.message = "Data not inserted some error occured";

            }
            return View("AddVideoPost");

        }
    }
}