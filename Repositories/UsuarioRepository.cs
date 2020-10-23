using ControleDeConteudo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeConteudo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeConteudo.Repositories
{
    public  class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioDbContext _contexto;
        public UsuarioRepository(UsuarioDbContext ctx)
        {
            _contexto = ctx;
        }
        public Usuario GetUsuario(Usuario usuario)
        {
            return _contexto.Usuario.Where(x => x.Username.ToLower() == usuario.Username.ToLower() && x.Password == usuario.Password).FirstOrDefault();
        }

      
    }
}
