namespace Livraria.EntityFramework.DbContext
{
    using Microsoft.EntityFrameworkCore;

    internal class Model : DbContext, Interface
    {
        internal Model(DbContextOptions<Model> options) : base(options)
        {

        }
        public DbSet<Livro.Model> Livro { get; set; }
    }
}