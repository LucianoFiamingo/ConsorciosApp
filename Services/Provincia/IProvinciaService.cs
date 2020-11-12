using Entities;
using Entities.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Services
{
    public interface IProvinciaService
    {
        List<SelectListItem> ObtenerComboProvincias();

        List<SelectListItem> ObtenerComboProvincias(int id);

    }
}
