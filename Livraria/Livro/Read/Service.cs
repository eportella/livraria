namespace Livraria.Livro.Read
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Service
    {
        public static IEnumerable<Interface> Call(Func<IQueryable<EntityFramework.Livro.Model>, IQueryable<EntityFramework.Livro.Model>> function = null)
        {
            using (var db = EntityFramework.DbContext.Service.MemoryNew())
            {
                db.ChangeTracker.AutoDetectChangesEnabled = false;
                db.ChangeTracker.LazyLoadingEnabled = false;

                var query = db.Livro.AsQueryable();

                if (function != null)
                    query = function(query);

                foreach (var item in query)
                    yield return Livro.Service.Create(item);
            }
        }
    }
}