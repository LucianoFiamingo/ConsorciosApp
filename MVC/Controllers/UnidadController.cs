﻿using Entities;
using Entities.EDMX;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class UnidadController : Controller
    {
        UnidadService UnidadService;
        ConsorcioService ConsorcioService;
        BreadcrumpService BreadcrumpService;

        public UnidadController()
        {
            PW3_TP_20202CEntities contexto = new PW3_TP_20202CEntities();
            UnidadService = new UnidadService(contexto);
            ConsorcioService = new ConsorcioService(contexto);
            BreadcrumpService = new BreadcrumpService();
        }

        public ActionResult VerUnidades(int? id)
        {
            if (id == null)
            {
                return Redirect("/Consorcio/Listado");
            }
            if (String.IsNullOrEmpty(Session["usuarioId"].ToString()))
            {
                TempData["Redirect"] = "/Unidad/VerUnidades" + id;
                return Redirect("/Home/Ingresar");
            }

            Consorcio cons = ConsorcioService.ObtenerPorId((int)id);
            ViewBag.IdConsorcio = id;
            int idUsuarioCreador = (int)Session["usuarioId"];
            List<Unidad> unidCons = UnidadService.ObtenerUnidadesPorConsorcioYOrdenadosPorNombre((int)id, idUsuarioCreador);

            Breadcrump nivel1 = new Breadcrump("Mis Consorcios", "Consorcio/Listado");
            Breadcrump nivel2 = new Breadcrump("Consorcio " + cons.Nombre.ToString(), "Consorcio/ModificarUnidad/" + id);
            Breadcrump nivel3 = new Breadcrump("Unidades");
            ViewBag.Breadcrumps = BreadcrumpService.SetListaBreadcrumps(nivel1, nivel2, nivel3);

            return View(unidCons);
        }

        public ActionResult CrearUnidad(int? id)
        {
            if (id == null)
            {
                return Redirect("/Consorcio/Listado");
            }
            if (String.IsNullOrEmpty(Session["usuarioId"].ToString()))
            {
                TempData["Redirect"] = "/Unidad/CrearUnidad" + id;
                return Redirect("/Home/Ingresar");
            }
            TempData["IdConsorcio"] = (int)id;
            Consorcio cons = ConsorcioService.ObtenerPorId((int)id);
            ViewBag.Consorcio = cons;

            Breadcrump nivel1 = new Breadcrump("Mis Consorcios", "Consorcio/Listado");
            Breadcrump nivel2 = new Breadcrump("Consorcio " + cons.Nombre.ToString(), "Unidad/ModificarUnidad/" + id);
            Breadcrump nivel3 = new Breadcrump("Unidades", "Unidad/VerUnidades/" + id);
            Breadcrump nivel4 = new Breadcrump("Crear Unidad");
            ViewBag.Breadcrumps = BreadcrumpService.SetListaBreadcrumps(nivel1, nivel2, nivel3, nivel4);

            return View();

        }

        [HttpPost]
        public ActionResult CrearUnidad(Unidad unid, string otraAccion)
        {
            if (String.IsNullOrEmpty(Session["usuarioId"].ToString()))
            {
                TempData["Redirect"] = "/Unidad/CrearUnidad" + unid.IdConsorcio;
                return Redirect("/Home/Ingresar");
            }

            unid.IdUsuarioCreador = (int)Session["usuarioId"];
            unid.FechaCreacion = DateTime.Now;

            if (!ModelState.IsValid)
            {
                int id = (int)TempData["IdConsorcio"];
                Consorcio cons = ConsorcioService.ObtenerPorId(id);
                ViewBag.Consorcio = cons;

                Breadcrump nivel1 = new Breadcrump("Mis Consorcios", "Consorcio/Listado");
                Breadcrump nivel2 = new Breadcrump("Consorcio " + cons.Nombre.ToString(), "Unidad/ModificarUnidad/" + cons.IdConsorcio);
                Breadcrump nivel3 = new Breadcrump("Unidades", "Unidad/VerUnidades/" + cons.IdConsorcio);
                Breadcrump nivel4 = new Breadcrump("Crear Unidad");
                ViewBag.Breadcrumps = BreadcrumpService.SetListaBreadcrumps(nivel1, nivel2, nivel3, nivel4);

                return View(unid);
            }

            UnidadService.Alta(unid);
            TempData["Creado"] = unid.Nombre.ToString();

            if (otraAccion == "crearOtro")
            {
                return Redirect("/Unidad/CrearUnidad/" + unid.IdConsorcio);
            }

            return Redirect("/Unidad/VerUnidades/" + unid.IdConsorcio);
        }

        public ActionResult ModificarUnidad(int? id)
        {
            if (id == null)
            {
                return Redirect("/Consorcio/Listado");
            }
            if (String.IsNullOrEmpty(Session["usuarioId"].ToString()))
            {
                TempData["Redirect"] = "/Unidad/ModificarUnidad" + id;
                return Redirect("/Home/Ingresar");
            }

            Unidad unid = UnidadService.ObtenerPorId((int)id);

            int idUs = (int)unid.Consorcio.IdUsuarioCreador;
            if (idUs != (int)Session["usuarioId"])
            {
                return Redirect("/Consorcio/Listado");
            }

            Breadcrump nivel1 = new Breadcrump("Mis Consorcios", "Consorcio/Listado");
            Breadcrump nivel2 = new Breadcrump("Consorcio " + unid.Consorcio.Nombre.ToString(), "Unidad/ModificarUnidad/" + unid.Consorcio.IdConsorcio);
            Breadcrump nivel3 = new Breadcrump("Unidades", "Unidad/VerUnidades/" + unid.Consorcio.IdConsorcio);
            Breadcrump nivel4 = new Breadcrump("Modificar Unidad");
            ViewBag.Breadcrumps = BreadcrumpService.SetListaBreadcrumps(nivel1, nivel2, nivel3, nivel4);

            return View(unid);
        }

        [HttpPost]
        public ActionResult ModificarUnidad(Unidad unid)
        {
            if (String.IsNullOrEmpty(Session["usuarioId"].ToString()))
            {
                TempData["Redirect"] = "/Unidad/ModificarUnidad" + unid.IdConsorcio;
                return Redirect("/Home/Ingresar");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Consorcio = unid.Consorcio;

                Breadcrump nivel1 = new Breadcrump("Mis Consorcios", "Consorcio/Listado");
                Breadcrump nivel2 = new Breadcrump("Consorcio " + unid.Consorcio.Nombre.ToString(), "Unidad/ModificarUnidad/" + unid.Consorcio.IdConsorcio);
                Breadcrump nivel3 = new Breadcrump("Unidades", "Unidad/VerUnidades/" + unid.Consorcio.IdConsorcio);
                Breadcrump nivel4 = new Breadcrump("Modificar Unidad");
                ViewBag.Breadcrumps = BreadcrumpService.SetListaBreadcrumps(nivel1, nivel2, nivel3, nivel4);

                return View(unid);
            }

            UnidadService.Modificar(unid);

            return Redirect("/Unidad/VerUnidades/" + unid.IdConsorcio);
        }


        public ActionResult EliminarUnidad(int? id)
        {
            if (String.IsNullOrEmpty(Session["usuarioId"].ToString()))
            {
                TempData["Redirect"] = "/Unidad/EliminarUnidad" + id;
                return Redirect("/Home/Ingresar");
            }
            if (id == null)
            {
                return Redirect("/Consorcio/Listado");
            }

            Unidad unid = UnidadService.ObtenerPorId((int)id);
            int idUs = (int)unid.Consorcio.IdUsuarioCreador;
            if (idUs != (int)Session["usuarioId"])
            {
                return RedirectToAction("Listado/" + unid.IdConsorcio);
            }

            Breadcrump nivel1 = new Breadcrump("Mis Consorcios", "Consorcio/Listado");
            Breadcrump nivel2 = new Breadcrump("Consorcio" + unid.Consorcio.Nombre.ToString(), "Unidad/Modificar/" + unid.IdConsorcio.ToString());
            Breadcrump nivel3 = new Breadcrump("Eliminar");
            ViewBag.Breadcrumps = BreadcrumpService.SetListaBreadcrumps(nivel1, nivel2, nivel3);
            return View(unid);

        }

        [HttpPost]
        public ActionResult EliminarUnidad(Unidad unidad)
        {

            if (unidad == null)
            {
                return Redirect("/Consorcio/Listado");
            }
            if (String.IsNullOrEmpty(Session["usuarioId"].ToString()))
            {
                TempData["Redirect"] = "/Unidad/EliminarUnidad/" + unidad.IdConsorcio;
                return Redirect("/Home/Ingresar");
            }

            TempData["Eliminado"] = unidad.Nombre.ToString();
            UnidadService.Eliminar(unidad.IdUnidad);

            return Redirect("/Unidad/VerUnidades/" + unidad.IdConsorcio);
        }

        public String Existe(string nombre, string idUsuCre, string idCon, string idUni)
        {
            Boolean existe;

            if (string.IsNullOrEmpty(idUni))
            {
                existe = UnidadService.ExisteNombre(nombre, Convert.ToInt32(idUsuCre), Convert.ToInt32(idCon));
            }
            else
            {
                existe = UnidadService.ExisteNombre(nombre, Convert.ToInt32(idUsuCre), Convert.ToInt32(idCon), Convert.ToInt32(idUni));
            }

            if (existe)
            {
                return "Ya existe una unidad con el mismo nombre";
            }
            return null;
        }
    }
}

