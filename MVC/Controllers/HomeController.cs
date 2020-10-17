using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }

       
        public ActionResult Ingresar()
        {
            
            return View();
        }
        
        /*[HttpPost]
        public ActionResult Ingresar(Usuario usuario)
        {
            return View();
        }
        */
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}