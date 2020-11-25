using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Entities;
using Entities.EDMX;
using Repositories;
using Repositories.Gasto;

namespace Services.Gastos
{
   public class TipoGastoService : BaseService<TipoGastoRepository,TipoGasto>, ITipoGastoService
    {
      
        public TipoGastoService(PW3_TP_20202CEntities contexto) : base(contexto)
        {
        }
        public List<SelectListItem> ObtenerComboTipoGasto()
        {
            List<TipoGasto> gastos = repo.ObtenerTodos();

            List<SelectListItem> TipoGastoItems = gastos.Select(o => new SelectListItem()
            {
                Text = o.Nombre,
                Value = o.IdTipoGasto.ToString()
            }).ToList();

            TipoGastoItems.Insert(0, new SelectListItem() { Value = "", Text = "Seleccione un tipo de gasto" });

            return TipoGastoItems;
        }

        public List<SelectListItem> ObtenerComboTipoGasto(int id)
        {
            List<TipoGasto> gastos = repo.ObtenerTodos();

            List<SelectListItem> TipoGastoItems = gastos.Select(o => new SelectListItem()
            {
                Text = o.Nombre,
                Value = o.IdTipoGasto.ToString(),
                Selected = o.IdTipoGasto == id
            }).ToList();

            TipoGastoItems.Insert(0, new SelectListItem() { Value = "", Text = "Seleccione un tipo de gasto" });

            return TipoGastoItems;
        }
    }
}
