namespace Livraria.EntityFramework.Livro
{
    using Livraria.Livro;

    internal static class Service
    {
        internal static Model Convert(Interface @interface) =>
            new Model
            {
                Autor = @interface.Autor,
                CapaImagemConteudo = @interface.CapaImagemConteudo,
                ISBN = @interface.ISBN,
                Nome = @interface.Nome,
                Preco = @interface.Preco,
                PublicacaoData = @interface.PublicacaoData
            };

        internal static void Modify(Model entity, Interface livro)
        {
            entity.Nome = livro.Nome;
            entity.Preco = livro.Preco;
            entity.PublicacaoData = livro.PublicacaoData;
            entity.Autor = livro.Autor;
            entity.CapaImagemConteudo = livro.CapaImagemConteudo;
        }
    }
}
