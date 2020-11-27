using Entities.EDMX;
using System;

namespace Repositories
{
    public interface IUsuarioRepository
    {
        Usuario validarInicioSesion(String email, String password);
    }
}
