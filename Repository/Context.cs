
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options ) : base (options)
        {

        }


        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Tema> Temas { get; set; }
        public DbSet<Artigo> Artigos { get; set; }
        public DbSet<Contratacao> Contratacoes { get; set; }

    }
}
