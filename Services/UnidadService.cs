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

        public static Unidad ObtenerPorId(int id)
        {
            return Lista.Find(o => o.IdUnidad == id);
        }

        public static void ModificarUnidad(Unidad a)
        {
            Unidad b = ObtenerPorId(a.IdUnidad);
            b.IdUnidad = a.IdUnidad;
            b.IdConsorcio = a.IdConsorcio;
            b.Nombre = a.Nombre;
            b.NombrePropietario = a.NombrePropietario;
            b.ApellidoPropietario = a.ApellidoPropietario;
            b.EmailPropietario = a.EmailPropietario;
            b.Superficie = a.Superficie;
        }

        public static void EliminarUnidad(int id)
        {
            Lista.RemoveAll(o => o.IdUnidad == id);
        }

    }
}
