namespace Livraria.EntityFramework.Livro
{
    internal static class Service
    {
        internal static Model Convert(Livraria.Livro.Interface @interface) =>
            new Model
            {
                Autor = @interface.Autor,
                CapaImagemConteudo = @interface.CapaImagemConteudo,
                ISBN = @interface.ISBN,
                Nome = @interface.Nome,
                Preco = @interface.Preco,
                PublicacaoData = @interface.PublicacaoData
            };
    }
}
