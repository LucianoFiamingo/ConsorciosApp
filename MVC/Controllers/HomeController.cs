using Entities;
using Entities.EDMX;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        BreadcrumpService BreadcrumpService;

        public HomeController()
        {
            PW3_TP_20202CEntities contexto = new PW3_TP_20202CEntities();
            BreadcrumpService = new BreadcrumpService();
        }
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
        public ActionResult Registrar()
        {
            return View();
        }
       
    }
}