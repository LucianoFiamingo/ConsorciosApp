using System.Collections.Generic;
using System.Web.Mvc;

namespace Services
{
    public interface ITipoGastoService
    {
        List<SelectListItem> ObtenerComboTipoGasto();
        List<SelectListItem> ObtenerComboTipoGasto(int id);
    }
}
