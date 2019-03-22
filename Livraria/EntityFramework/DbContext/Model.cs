namespace Livraria.EntityFramework.DbContext
{
    using Microsoft.EntityFrameworkCore;

    internal class Model : DbContext
    {
        internal Model(DbContextOptions<Model> options) : base(options)
        {

        }
        public DbSet<Livro.Model> Livro { get; set; }
        public DbSet<Autor.Model> Autor { get; set; }
    }
}