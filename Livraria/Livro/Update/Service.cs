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

                entity.Nome = livro.Nome;
                entity.Preco = livro.Preco;
                entity.PublicacaoData = livro.PublicacaoData;
                entity.Autor = livro.Autor;
                entity.CapaImagemConteudo = livro.CapaImagemConteudo;

                db.Livro.Update(entity);

                return db.SaveChangesAsync();
            }
        }
    }
}