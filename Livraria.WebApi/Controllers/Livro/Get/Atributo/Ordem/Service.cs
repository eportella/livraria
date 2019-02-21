namespace Livraria.WebApi.Controllers.Livro.Get.Atributo.Ordem
{
    using System.Linq;
    public static class Service
    {
        internal static IQueryable<EntityFramework.Livro.Model> Call(this Model ordem, IQueryable<EntityFramework.Livro.Model> query)
        {
            if (ordem == null)
                return query;

            if (ordem.Direcao == 'A')
            {
                if (ordem.Nome == nameof(Livraria.Livro.Model.ISBN))
                    query = query.OrderBy(o => o.ISBN);

                else if (ordem.Nome == nameof(Livraria.Livro.Model.Autor))
                    query = query.OrderBy(o => o.Autor);

                else if (ordem.Nome == nameof(Livraria.Livro.Model.Nome))
                    query = query.OrderBy(o => o.Nome);

                else if (ordem.Nome == nameof(Livraria.Livro.Model.Preco))
                    query = query.OrderBy(o => o.Preco);

                else if (ordem.Nome == nameof(Livraria.Livro.Model.PublicacaoData))
                    query = query.OrderBy(o => o.PublicacaoData);

            }

            if (ordem.Direcao == 'D')
            {
                if (ordem.Nome == nameof(Livraria.Livro.Model.ISBN))
                    query = query.OrderByDescending(o => o.ISBN);

                else if (ordem.Nome == nameof(Livraria.Livro.Model.Autor))
                    query = query.OrderByDescending(o => o.Autor);

                else if (ordem.Nome == nameof(Livraria.Livro.Model.Nome))
                    query = query.OrderByDescending(o => o.Nome);

                else if (ordem.Nome == nameof(Livraria.Livro.Model.Preco))
                    query = query.OrderByDescending(o => o.Preco);

                else if (ordem.Nome == nameof(Livraria.Livro.Model.PublicacaoData))
                    query = query.OrderByDescending(o => o.PublicacaoData);
            }

            return query;
        }
    }
}