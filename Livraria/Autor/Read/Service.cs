namespace Livraria.Autor.Read
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Service
    {
        public static IEnumerable<string> Call(Func<IQueryable<EntityFramework.Autor.Model>, IQueryable<EntityFramework.Autor.Model>> function = null)
        {
            using (var db = EntityFramework.DbContext.Service.MemoryNew())
            {
                db.ChangeTracker.AutoDetectChangesEnabled = false;
                db.ChangeTracker.LazyLoadingEnabled = false;

                var query = db.Autor.AsQueryable();

                if (function != null)
                    query = function(query);

                foreach (var item in query)
                    yield return Autor.Service.Create(item);
            }
        }
    }
}