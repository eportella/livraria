namespace Livraria.Livro.Read
{
    using Livraria.EntityFramework.Livro;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public static class Service
    {
        public static IEnumerable<Interface> Call(Func<IQueryable<EntityFramework.Livro.Model>, IQueryable<EntityFramework.Livro.Model>> function = null, IEnumerable<Expression<Func<EntityFramework.Livro.Model, object>>> include = null)
        {
            using (var db = EntityFramework.DbContext.Service.MemoryNew())
            {
                db.ChangeTracker.AutoDetectChangesEnabled = false;
                db.ChangeTracker.LazyLoadingEnabled = false;

                var query = db.Livro.AsQueryable();

                if (function != null)
                    query = function(query);

                if (include != null)
                    foreach (var item in include)
                        query = query.Include(item);

                foreach (var item in query)
                    yield return Livro.Service.Create(item);
            }
        }

        public static object Call(Func<IQueryable<Model>, IQueryable<Model>> p1, object[] p2)
        {
            throw new NotImplementedException();
        }
    }
}