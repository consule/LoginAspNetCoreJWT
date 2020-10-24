using ControleDeConteudo.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeConteudo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Usuario> Usuario { get; set; }
    }
}