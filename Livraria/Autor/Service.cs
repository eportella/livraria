namespace Livraria.Autor
{
    internal class Service
    {
        internal static string Create(EntityFramework.Autor.Model item)
        {
            return item.Nome;
        }
    }
}