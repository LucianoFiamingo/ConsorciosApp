using Entities.EDMX;
using Repositories;
using System.Collections.Generic;

namespace Services
{
    public class UsuarioService : BaseService<UsuarioRepository, Usuario>, IUsuarioService
    {
        public UsuarioService(PW3_TP_20202CEntities contexto) : base(contexto)
        {
        }

        public bool existeEmail(string email)
        {
            bool resultado=true;
            List<Usuario> list = repo.ObtenerTodos();

            foreach (Usuario usu in list)
            {
                if (usu.Email.Equals(email))
                {
                    return resultado = true;
                }
                else
                {
                    return resultado = false;
                }
            }
            return resultado;

        }

        public Usuario validarInicioSesion(string email, string password)
        {
            return repo.validarInicioSesion(email, password);
        }

        
    }
}
