namespace Livraria.Autor.Delete
{
    using System.Linq;
    using System.Threading.Tasks;

    public static class Service
    {
        public static Task Call(string autor)
        {
            using (var db = EntityFramework.DbContext.Service.MemoryNew())
            {
                var entity = db.Autor.SingleOrDefault(Expression.NomeHas(autor));

                if (entity == null)
                    throw new Exception.Model($"{nameof(autor)} ({autor}) não encontrado");

                db.Autor.Remove(entity);
                return db.SaveChangesAsync();
            }
        }
    }
}