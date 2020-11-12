using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Usuario
{
    public interface IUsuarioRepository
    {
        Entities.EDMX.Usuario validarInicioSesion(String email, String password);
    }
}
