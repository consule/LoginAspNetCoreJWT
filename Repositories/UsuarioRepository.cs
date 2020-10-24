using ControleDeConteudo.Models;
using System.Linq;
using ControleDeConteudo.Data;

namespace ControleDeConteudo.Repositories
{
    public  class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _contexto;
        public UsuarioRepository(DataContext ctx)
        {
            _contexto = ctx;
        }
        public Usuario GetUsuario(Usuario usuario)
        {
            return _contexto.Usuario.Where(x => x.Username.ToLower() == usuario.Username.ToLower() && x.Password == usuario.Password).FirstOrDefault();
        }      
    }
}
