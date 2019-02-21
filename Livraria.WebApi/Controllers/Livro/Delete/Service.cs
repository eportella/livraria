namespace Livraria.WebApi.Controllers.Livro.Delete
{
    using System.Threading.Tasks;

    public static class Service
    {
        public static async Task<Envelope.Model> Call(Livraria.Livro.Model livro)
        {
            try
            {
                await Livraria.Livro.Service.Delete(livro);
                return new Envelope.Model();
            }
            catch (Exception.Model ex)
            {
                return new Envelope.Model
                {
                    mensagem = ex.Message
                };
            }
        }
    }
}
