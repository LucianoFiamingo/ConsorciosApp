using Entities.EDMX;
using Repositories;

namespace Services
{
    public class UsuarioService : BaseService<UsuarioRepository, Usuario>, IUsuarioService
    {
        public UsuarioService(PW3_TP_20202CEntities contexto) : base(contexto)
        {
        }

        public Usuario validarInicioSesion(string email, string password)
        {
            return repo.validarInicioSesion(email, password);
        }

        
    }
}
