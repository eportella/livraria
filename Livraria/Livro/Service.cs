namespace Livraria.Livro
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class Service
    {
        public static Task Create(Interface @interface)
        {
            using (var db = EntityFramework.DbContext.Service.MemoryNew())
            {
                if (db.Livro.Any(Expression.ISBNHas(@interface)))
                    throw new Livraria.Exception.Model($"{nameof(@interface.ISBN)} ({@interface.ISBN}) já cadastrado");

                db.Livro.Add(EntityFramework.Livro.Service.Convert(@interface));
                return db.SaveChangesAsync();
            }
        }

        public static IEnumerable<EntityFramework.Livro.Model> Read(Func<IQueryable<EntityFramework.Livro.Model>, IQueryable<EntityFramework.Livro.Model>> function = null)
        {
            using (var db = EntityFramework.DbContext.Service.MemoryNew())
            {
                db.ChangeTracker.AutoDetectChangesEnabled = false;
                db.ChangeTracker.LazyLoadingEnabled = false;

                var query = db.Livro.AsQueryable();

                if (function != null)
                    query = function(query);

                foreach (var item in query)
                    yield return item;
            }
        }

        public static Task Update(Interface @interface)
        {
            using (var db = EntityFramework.DbContext.Service.MemoryNew())
            {
                var livro = db.Livro.SingleOrDefault(Expression.ISBNHas(@interface));

                if (livro == null)
                    throw new Livraria.Exception.Model($"{nameof(@interface.ISBN)} ({@interface.ISBN}) não encontrado");

                livro.Nome = @interface.Nome;
                livro.Preco = @interface.Preco;
                livro.PublicacaoData = @interface.PublicacaoData;
                livro.Autor = @interface.Autor;
                livro.CapaImagemConteudo = @interface.CapaImagemConteudo;

                db.Livro.Update(livro);

                return db.SaveChangesAsync();
            }
        }

        public static Task Delete(Interface @interface)
        {
            using (var db = EntityFramework.DbContext.Service.MemoryNew())
            {
                var entity = db.Livro.SingleOrDefault(Expression.ISBNHas(@interface));

                if (entity == null)
                    throw new Livraria.Exception.Model($"{nameof(@interface.ISBN)} ({@interface.ISBN}) não encontrado");

                db.Livro.Remove(entity);
                return db.SaveChangesAsync();
            }
        }
    }
}