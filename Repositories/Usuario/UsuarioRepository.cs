using Entities.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Usuario
{
   public class UsuarioRepository : BaseRepository<Entities.EDMX.Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(PW3_TP_20202CEntities contexto) : base(contexto)
        {

        }

        public override void Modificar(Entities.EDMX.Usuario t)
        {
           Entities.EDMX.Usuario usu = ObtenerPorId(t.IdUsuario);
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

        public Entities.EDMX.Usuario validarInicioSesion(string email, string password)
        {
            Entities.EDMX.Usuario usu= (Entities.EDMX.Usuario)(from usuario in ctx.Usuarios
                                    where usuario.Email.Equals(email) && usuario.Password.Equals(password)
                                    select usuario);

            return usu;
        }
    }
}
