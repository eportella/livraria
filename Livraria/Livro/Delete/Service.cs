namespace Livraria.Livro.Delete
{
    using System.Linq;
    using System.Threading.Tasks;

    public static class Service
    {
        public static Task Call(Interface livro)
        {
            using (var db = EntityFramework.DbContext.Service.MemoryNew())
            {
                var entity = db.Livro.SingleOrDefault(Expression.ISBNHas(livro));

                if (entity == null)
                    throw new Livraria.Exception.Model($"{nameof(livro.ISBN)} ({livro.ISBN}) não encontrado");

                db.Livro.Remove(entity);
                return db.SaveChangesAsync();
            }
        }
    }
}