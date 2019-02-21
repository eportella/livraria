namespace Livraria.Livro
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class Service
    {
        public static Task Create(Interface livro)
        {
            using (var db = EntityFramework.DbContext.Service.MemoryNew())
            {
                if (db.Livro.Any(Expression.ISBNHas(livro)))
                    throw new Livraria.Exception.Model($"{nameof(livro.ISBN)} ({livro.ISBN}) já cadastrado");

                db.Livro.Add(EntityFramework.Livro.Service.Convert(livro));
                return db.SaveChangesAsync();
            }
        }

        public static IEnumerable<Livro.Interface> Read(Func<IQueryable<EntityFramework.Livro.Model>, IQueryable<EntityFramework.Livro.Model>> function = null)
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

        public static Task Update(Interface livro)
        {
            using (var db = EntityFramework.DbContext.Service.MemoryNew())
            {
                var entity = db.Livro.SingleOrDefault(Expression.ISBNHas(livro));

                if (entity == null)
                    throw new Livraria.Exception.Model($"{nameof(livro.ISBN)} ({livro.ISBN}) não encontrado");

                entity.Nome = livro.Nome;
                entity.Preco = livro.Preco;
                entity.PublicacaoData = livro.PublicacaoData;
                entity.Autor = livro.Autor;
                entity.CapaImagemConteudo = livro.CapaImagemConteudo;

                db.Livro.Update(entity);

                return db.SaveChangesAsync();
            }
        }

        public static Task Delete(Interface livro)
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