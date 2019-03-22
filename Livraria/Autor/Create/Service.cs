namespace Livraria.Autor.Create
{
    using System.Linq;
    using System.Threading.Tasks;

    public static class Service
    {
        public static Task Call(string autor)
        {
            using (var db = EntityFramework.DbContext.Service.MemoryNew())
            {
                if (db.Autor.Any(Expression.NomeHas(autor)))
                    throw new Exception.Model($"{nameof(autor)} ({autor}) já cadastrado");

                db.Autor.Add(EntityFramework.Autor.Service.Convert(autor));
                return db.SaveChangesAsync();
            }
        }
    }
}