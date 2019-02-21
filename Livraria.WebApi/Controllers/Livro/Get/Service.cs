namespace Livraria.WebApi.Controllers.Livro.Get
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public static class Service
    {
        public static Task<Envelope.Model<IEnumerable<Livraria.Livro.Interface>>> Call(Model get) =>
            Task.Run(() => new Envelope.Model<IEnumerable<Livraria.Livro.Interface>>
            {
                resultado = Livraria.Livro.Service.Read(function: query =>
                {
                     return query;
                })
             });
    }
}
