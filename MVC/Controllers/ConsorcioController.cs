using System.Collections.Generic;
using System.Web.Mvc;
using Entidades;
using Servicios;

namespace MVC.Controllers
{
    public class ConsorcioController : Controller
    {
        ConsorcioService consorcioService;
        public ConsorcioController()
        {
            this.consorcioService = new ConsorcioService();
        }

        public ActionResult Listado()
        {
            List<Consorcio> consorcios = consorcioService.GetAll();
            return View(consorcios);
        }

    }
}