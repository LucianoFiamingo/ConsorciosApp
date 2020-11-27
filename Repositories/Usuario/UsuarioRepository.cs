using Entities.EDMX;
using System.Linq;

namespace Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(PW3_TP_20202CEntities contexto) : base(contexto)
        {
        }
        public override void Modificar(Usuario t)
        {
            Usuario usu = ObtenerPorId(t.IdUsuario);
            usu.Email = t.Email;
            usu.Consorcios = t.Consorcios;
            usu.FechaRegistracion = t.FechaRegistracion;
            usu.FechaUltLogin = t.FechaUltLogin;
            usu.Gastoes = t.Gastoes;
            usu.Password = t.Password;
            usu.Unidads = t.Unidads;
            usu.IdUsuario = t.IdUsuario;

            ctx.SaveChanges();
        }
        public Usuario validarInicioSesion(string email, string password)
        {
            var usuQuery = (from usuario in ctx.Usuarios
                            where usuario.Email.Equals(email) && usuario.Password.Equals(password)
                            select usuario);

            if (usuQuery.Count() > 0)
            {
                Usuario us = usuQuery.First();
                return us;
            }
            return null;
        }
    }
}
