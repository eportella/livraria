namespace Livraria.EntityFramework.Autor
{
    internal static class Service
    {
        internal static Model Convert(string autor) =>
            new Model
            {
                Nome = autor,
            };
    }
}