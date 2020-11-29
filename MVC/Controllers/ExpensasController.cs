using Entities;
using Entities.DTO;
using Entities.EDMX;
using Services;
using System;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ExpensasController : Controller
    {
        ConsorcioService ConsorcioService;
        ExpensasService ExpensasService;
        BreadcrumpService BreadcrumpService;

        public ExpensasController()
        {
            PW3_TP_20202CEntities contexto = new PW3_TP_20202CEntities();
            ConsorcioService = new ConsorcioService(contexto);
            ExpensasService = new ExpensasService(contexto);
            BreadcrumpService = new BreadcrumpService();
        }

        public ActionResult Ver(int? id)
        {
            if (String.IsNullOrEmpty(Session["usuarioId"].ToString()))
            {
                return Redirect("/Home/Ingresar");
            }

            if (id == null)
            {
                return Redirect("/Consorcio/Listado");
            }
            
            ExpensaDTO expensas = ExpensasService.GetExpensas((int)id);

            string nombre = ConsorcioService.ObtenerPorId((int)id).Nombre;
            ViewBag.NombreConsorcio = nombre;

            Breadcrump nivel1 = new Breadcrump("Mis Consorcios", "Consorcio/Listado");
            Breadcrump nivel2 = new Breadcrump("Consorcio " + nombre, "Expensas/Ver/" + id.ToString());
            Breadcrump nivel3 = new Breadcrump("Expensas");

            ViewBag.Breadcrumps = BreadcrumpService.SetListaBreadcrumps(nivel1, nivel2, nivel3);

            return View(expensas);
        }

    }
}