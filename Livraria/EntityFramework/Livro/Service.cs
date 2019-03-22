namespace Livraria.EntityFramework.Livro
{
    using Livraria.Livro;

    internal static class Service
    {
        internal static Model Create(Interface livro) =>
            new Model
            {
                CapaImagemConteudo = livro.CapaImagemConteudo,
                ISBN = livro.ISBN,
                Nome = livro.Nome,
                Preco = livro.Preco,
                PublicacaoData = livro.PublicacaoData,
                Autor = new Autor.Model
                {
                    Nome = livro.Autor
                }
            };
        
        internal static void Modify(Model entity, Interface livro)
        {
            entity.Nome = livro.Nome;
            entity.Preco = livro.Preco;
            entity.PublicacaoData = livro.PublicacaoData;
            entity.CapaImagemConteudo = livro.CapaImagemConteudo;
        }
    }
}
