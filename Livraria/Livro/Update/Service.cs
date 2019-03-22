namespace Livraria.Livro.Update
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    public static class Service
    {
        public static Task Call(Interface livro)
        {
            using (var db = EntityFramework.DbContext.Service.MemoryNew())
            {
                var entity = db.Livro.Include(i=>i.Autor).SingleOrDefault(Expression.ISBNHas(livro));

                if (entity == null)
                    throw new Exception.Model($"{nameof(livro.ISBN)} ({livro.ISBN}) não encontrado");

                EntityFramework.Livro.Service.Modify(entity, livro);

                if (entity.Autor.Nome != livro.Autor)
                {
                    var autor = db.Autor.SingleOrDefault(Autor.Expression.NomeHas(livro.Autor));
                    if (autor == null)
                    {
                        Autor.Create.Service.Call(livro.Autor).Wait();
                        autor = db.Autor.Single(Autor.Expression.NomeHas(livro.Autor));
                    }
                    entity.Autor = autor;
                }

                db.Livro.Update(entity);

                return db.SaveChangesAsync();
            }
        }
    }
}