namespace Livraria.Livro
{
    internal class Service
    {
        internal static Model Create(EntityFramework.Livro.Model item)
        {
            return new Model
            {
                Autor = item.Autor,
                ISBN = item.ISBN,
                CapaImagemConteudo = item.CapaImagemConteudo,
                Nome = item.Nome,
                Preco = item.Preco,
                PublicacaoData = item.PublicacaoData
            };
        }
    }
}