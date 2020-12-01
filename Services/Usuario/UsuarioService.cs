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

            if(repo.existeEmail(email) != null)
            {
                return true;
            }
            return false;

        }

        public Usuario validarInicioSesion(string email, string password)
        {
            return repo.validarInicioSesion(email, password);
        }

        
    }
}
