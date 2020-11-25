using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Services.Gastos
{
    public interface ITipoGastoService
    {
        List<SelectListItem> ObtenerComboTipoGasto();

        List<SelectListItem> ObtenerComboTipoGasto(int id);
    }
}
