using Entities.EDMX;
using Repositories;
using Repositories.Usuario;

namespace Services.Usuario
{
    public class UsuarioService : BaseService<Repositories.Usuario.UsuarioRepository, Entities.EDMX.Usuario>, IUsuarioService
    {
        public UsuarioService(PW3_TP_20202CEntities contexto) : base(contexto)
    {
    }

        public Entities.EDMX.Usuario validarInicioSesion(string email, string password)
        {
            return repo.validarInicioSesion(email, password);
        }
    }
}
