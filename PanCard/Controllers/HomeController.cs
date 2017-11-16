using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PanCard.Models;

namespace PanCard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpPost]
        public ActionResult Register(RegisterData form )
        {
            ViewBag.Message = "Your contact page.";
            LogFileWrite.write("form submitted Sucessfull.......");
            LogFileWrite.write("form submitted Sucessfull............");

            return View();
        }
    }
}