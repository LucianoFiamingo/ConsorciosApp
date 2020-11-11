using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Entities;
using Entities.EDMX;
using Repositories;

namespace Services
{
    public class ProvinciaService : BaseService<ProvinciaRepository, Provincia>, IProvinciaService
    {
        public ProvinciaService(PW3_TP_20202CEntities contexto) : base(contexto)
        {
        }

        public List<SelectListItem> ObtenerComboProvincias()
        {
            List<Provincia> provs = repo.ObtenerTodos();

            List<SelectListItem> ProvinciasItems = provs.Select(o => new SelectListItem()
            {
                Text = o.Nombre,
                Value = o.IdProvincia.ToString()
            }).ToList();

            ProvinciasItems.Insert(0, new SelectListItem() { Value = "", Text = "Seleccione una provincia" });

            return ProvinciasItems;
        }

        public List<SelectListItem> ObtenerComboProvincias(int id)
        {
            List<Provincia> provs = repo.ObtenerTodos();

            List<SelectListItem> ProvinciasItems = provs.Select(o => new SelectListItem()
            {
                Text = o.Nombre,
                Value = o.IdProvincia.ToString(),
                Selected = o.IdProvincia == id
            }).ToList();

            ProvinciasItems.Insert(0, new SelectListItem() { Value = "", Text = "Seleccione una provincia" });

            return ProvinciasItems;
        }
    }
}
