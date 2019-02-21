namespace Livraria.EntityFramework.DbContext.Options
{
    using Microsoft.EntityFrameworkCore;

    public static class Service
    {
        internal static DbContextOptions<Model> NewInMemory()
        {
            return new DbContextOptionsBuilder<Model>()
                .UseInMemoryDatabase(databaseName: "livraria")
                .Options;
        }
    }
}