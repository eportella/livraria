namespace Livraria.WebApi.Controllers.Livro.Post
{
    using System.Threading.Tasks;

    public static class Service
    {
        public static async Task<Envelope.Model> Call(Livraria.Livro.Model livro)
        {
            try
            {
                await Livraria.Livro.Create.Service.Call(livro);
                return Envelope.Service.Create();
            }
            catch (Exception.Model ex)
            {
                return Envelope.Service.Create(exception: ex);
            }
        }
    }
}
