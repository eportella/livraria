namespace Livraria.WebApi.Controllers.Livro.Get
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public static class Service
    {
        public static Task<Envelope.Model<IEnumerable<Livraria.Livro.Interface>>> Call(Model get) =>
            Task.Run(() => 
                Envelope.Service.Create(
                    resultado: Livraria.Livro.Read.Service.Call(function: query => 
                        Atributo.Ordem.Service.Call(get?.Atributo?.Ordem, Atributo.Filtro.Service.Call(get?.Atributo?.Filtro, query))
                    )
                )
            );
            
    }
}