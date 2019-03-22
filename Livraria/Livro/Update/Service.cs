namespace Livraria.Livro.Update
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
                    throw new Exception.Model($"{nameof(livro.ISBN)} ({livro.ISBN}) não encontrado");

                EntityFramework.Livro.Service.Modify(entity, livro);

                db.Livro.Update(entity);

                return db.SaveChangesAsync();
            }
        }
    }
}