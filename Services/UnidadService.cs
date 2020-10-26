using Entities.EDMX;
using System.Collections.Generic;
using System.Web;

namespace Servicios
{
    public class UnidadService
    {
        private static List<Unidad> Lista
        {
            get
            {
                if (HttpContext.Current.Session["Lista"] == null)
                    HttpContext.Current.Session["Lista"] = new List<Unidad>();
                return (List<Unidad>)HttpContext.Current.Session["Lista"];
            }
        }

        public static void CrearUnidad(Unidad a)
        {
            Lista.Add(a);
        }

        public static List<Unidad> ObtenerTodos()
        {
            return Lista;
        }

    }
}
