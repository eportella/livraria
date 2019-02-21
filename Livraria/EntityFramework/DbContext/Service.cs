namespace Livraria.EntityFramework.DbContext
{
    internal static class Service
    {
        internal static Model MemoryNew()
        {
            return new Model(Options.Service.NewInMemory());
        }
    }
}