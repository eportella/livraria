namespace Livraria.Livro.Create
{
    using System.Linq;
    using System.Threading.Tasks;

    public static class Service
    {
        public static Task Call(Interface livro)
        {
            using (var db = EntityFramework.DbContext.Service.MemoryNew())
            {
                if (db.Livro.Any(Expression.ISBNHas(livro)))
                    throw new Exception.Model($"{nameof(livro.ISBN)} ({livro.ISBN}) já cadastrado");

                db.Livro.Add(EntityFramework.Livro.Service.Convert(livro));
                return db.SaveChangesAsync();
            }
        }
    }
}