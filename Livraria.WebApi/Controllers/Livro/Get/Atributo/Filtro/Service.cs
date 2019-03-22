namespace Livraria.WebApi.Controllers.Livro.Get.Atributo.Filtro
{
    using System.Linq;
    public static class Service
    {
        internal static IQueryable<EntityFramework.Livro.Model> Call(this Model filtro, IQueryable<EntityFramework.Livro.Model> query)
        {
            if (filtro == null)
                return query;

            if (!string.IsNullOrWhiteSpace(filtro.ISBN?.Contem))
                query = query.Where(o => o.ISBN.Contains(filtro.ISBN.Contem));

            if (!string.IsNullOrWhiteSpace(filtro.Autor?.Contem))
                query = query.Where(o => o.Autor.Nome.Contains(filtro.Autor.Contem));

            if (!string.IsNullOrWhiteSpace(filtro.Nome?.Contem))
                query = query.Where(o => o.Nome.Contains(filtro.Nome.Contem));

            if (filtro.Preco != null)
            {
                if (filtro.Preco.Igual.HasValue)
                    query = query.Where(o => o.Preco == filtro.Preco.Igual);

                if (filtro.Preco.Acima.HasValue)
                    query = query.Where(o => o.Preco >= filtro.Preco.Acima);

                if (filtro.Preco.Abaixo.HasValue)
                    query = query.Where(o => o.Preco <= filtro.Preco.Abaixo);
            }

            if (filtro.PublicacaoData != null)
            {
                if (filtro.PublicacaoData.Igual.HasValue)
                    query = query.Where(o => o.PublicacaoData == filtro.PublicacaoData.Igual);

                if (filtro.PublicacaoData.Acima.HasValue)
                    query = query.Where(o => o.PublicacaoData >= filtro.PublicacaoData.Acima);

                if (filtro.PublicacaoData.Abaixo.HasValue)
                    query = query.Where(o => o.PublicacaoData <= filtro.PublicacaoData.Abaixo);
            }

            return query;
        }
    }
}