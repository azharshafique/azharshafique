using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotTrends.Models;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace HotTrends.Controllers
{
   
    public class HomeController : Controller
    {
        newssiteContext context = null;
        IHostingEnvironment env = null;
        public HomeController(IHostingEnvironment _env, newssiteContext _context)
        {
            context = _context;
            env = _env;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult homepage()
        {
            IList<Videopost> pl = context.Videopost.ToList<Videopost>();

            return View(pl);
        }
        public IActionResult single(int id)
        {

            ViewBag.array = context.Videopost.Where(e => e.VideoId == id).ToList<Videopost>();
            IList<Videopost> vp = ViewBag.array;
            StringBuilder sb = new StringBuilder();
            //foreach (var file in vp)
            //{
            //    var a = file.VideoName;
            //    IList<Videopost> pl = context.Videopost.Where(e => e.VideoName == a).ToList<Videopost>();
            //    return View(pl);
            //}
            
            foreach (var file in vp)
            {
               var a = file.VideoName;
               IList<Videopost> pl = context.Videopost.Where(e => e.VideoName == a).ToList<Videopost>();
                return View(pl);
                //foreach (var item in pl)
                //{
                //    sb.Append("<div class='single-right-grids'>");
                //    sb.Append("<div class='col-md-6'>");
                //    sb.Append("<a href='single?id=item.VideoId'>");
                //    sb.Append("<iframe class='img-responsive' src='item.VideoEmbed' frameborder='0' allowfullscreen>");
                //    sb.Append("</iframe>");
                //    sb.Append("<div class='w3l-action-icon'>");
                //    sb.Append("<i class='fa fa-play-circle' aria-hidden='true'>");
                //    sb.Append("</i>");
                //    sb.Append("</div>");
                //    sb.Append("</a>");
                //    sb.Append("</div>");
                //    sb.Append("<div class='col-md-6 single-right-grid-right'>");
                //    sb.Append("<a href='single?id=item.VideoId' class='title'>");
                //    sb.Append(item.VideoName);
                //    sb.Append("</a>");
                //    sb.Append("</div>");
                //    sb.Append("<div class='clearfix'>");
                //    sb.Append("</div>");
                    
                //}
            }


            return View();

        }
       

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult signup()
        {

            return View();
        }
        [HttpPost]
        public IActionResult signup(User u)
        {
            context.User.Add(u);
            context.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult signin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult signin(User u)
        {
            User query = context.User.Where(e => e.Email == u.Email && e.Password == u.Password).FirstOrDefault();
            if (query != null)
            {
                HttpContext.Session.SetString("username", query.FirstName);
                return RedirectToAction("homepage");
            }
            else
            {
                return RedirectToAction("signin");
            }
            
        }
    }
}
