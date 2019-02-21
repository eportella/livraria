namespace Livraria.EntityFramework.DbContext
{
    public static class Service
    {
        public static Interface MemoryNew()
        {
            return new Model(Options.Service.NewInMemory());
        }
    }
}