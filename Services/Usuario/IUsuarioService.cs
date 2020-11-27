using Entities.EDMX;
using System;

namespace Services
{
    public interface IUsuarioService
    {
        Usuario validarInicioSesion(String email, String password);
    }
}
