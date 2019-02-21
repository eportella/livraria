namespace Livraria.WebApi.Controllers.Livro.Get
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public static class Service
    {
        public static Task<Envelope.Model<IEnumerable<Livraria.Livro.Interface>>> Call(Model get) =>
            Task.Run(() => new Envelope.Model<IEnumerable<Livraria.Livro.Interface>>
            {
                resultado = Livraria.Livro.Service.Read(function: query =>
                {
                    if (get?.Atributo?.Filtro != null)
                    {
                        if (!string.IsNullOrWhiteSpace(get.Atributo.Filtro.ISBN?.Contem))
                            query = query.Where(o => o.ISBN.Contains(get.Atributo.Filtro.ISBN.Contem));

                        if (!string.IsNullOrWhiteSpace(get.Atributo.Filtro.Autor?.Contem))
                            query = query.Where(o => o.Autor.Contains(get.Atributo.Filtro.Autor.Contem));

                        if (!string.IsNullOrWhiteSpace(get.Atributo.Filtro.Nome?.Contem))
                            query = query.Where(o => o.Nome.Contains(get.Atributo.Filtro.Nome.Contem));

                        if (get.Atributo.Filtro.Preco != null)
                        {
                            if(get.Atributo.Filtro.Preco.Igual.HasValue)
                                query = query.Where(o => o.Preco == get.Atributo.Filtro.Preco.Igual);

                            if (get.Atributo.Filtro.Preco.Acima.HasValue)
                                query = query.Where(o => o.Preco >= get.Atributo.Filtro.Preco.Acima);

                            if (get.Atributo.Filtro.Preco.Abaixo.HasValue)
                                query = query.Where(o => o.Preco <= get.Atributo.Filtro.Preco.Abaixo);
                        }

                        if (get.Atributo.Filtro.PublicacaoData != null)
                        {
                            if (get.Atributo.Filtro.PublicacaoData.Igual.HasValue)
                                query = query.Where(o => o.PublicacaoData == get.Atributo.Filtro.PublicacaoData.Igual);

                            if (get.Atributo.Filtro.PublicacaoData.Acima.HasValue)
                                query = query.Where(o => o.PublicacaoData >= get.Atributo.Filtro.PublicacaoData.Acima);

                            if (get.Atributo.Filtro.PublicacaoData.Abaixo.HasValue)
                                query = query.Where(o => o.PublicacaoData <= get.Atributo.Filtro.PublicacaoData.Abaixo);
                        }
                        
                    }

                    if (get?.Atributo?.Ordem != null)
                    {
                        if (get.Atributo.Ordem.Direcao == 'A')
                        {
                            if (get.Atributo.Ordem.Nome == nameof(Livraria.Livro.Model.ISBN))
                                query = query.OrderBy(o => o.ISBN);

                            else if (get.Atributo.Ordem.Nome == nameof(Livraria.Livro.Model.Autor))
                                query = query.OrderBy(o => o.Autor);

                            else if (get.Atributo.Ordem.Nome == nameof(Livraria.Livro.Model.Nome))
                                query = query.OrderBy(o => o.Nome);

                            else if (get.Atributo.Ordem.Nome == nameof(Livraria.Livro.Model.Preco))
                                query = query.OrderBy(o => o.Preco);

                            else if (get.Atributo.Ordem.Nome == nameof(Livraria.Livro.Model.PublicacaoData))
                                query = query.OrderBy(o => o.PublicacaoData);

                        }

                        if (get.Atributo.Ordem.Direcao == 'D')
                        {
                            if (get.Atributo.Ordem.Nome == nameof(Livraria.Livro.Model.ISBN))
                                query = query.OrderByDescending(o => o.ISBN);

                            else if (get.Atributo.Ordem.Nome == nameof(Livraria.Livro.Model.Autor))
                                query = query.OrderByDescending(o => o.Autor);

                            else if (get.Atributo.Ordem.Nome == nameof(Livraria.Livro.Model.Nome))
                                query = query.OrderByDescending(o => o.Nome);

                            else if (get.Atributo.Ordem.Nome == nameof(Livraria.Livro.Model.Preco))
                                query = query.OrderByDescending(o => o.Preco);

                            else if (get.Atributo.Ordem.Nome == nameof(Livraria.Livro.Model.PublicacaoData))
                                query = query.OrderByDescending(o => o.PublicacaoData);
                        }

                    }
                    return query;
                })
            });
    }
}