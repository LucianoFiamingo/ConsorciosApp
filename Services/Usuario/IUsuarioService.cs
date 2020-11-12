using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Usuario
{
    public interface IUsuarioService
    {
        Entities.EDMX.Usuario validarInicioSesion(String email, String password);
    }
}
