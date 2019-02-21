namespace Livraria.WebApi.Controllers.Envelope
{
    public class Model<TResult>
    {
        public string mensagem { get; set; }
        public TResult resultado { get; set; }
    }
    public class Model
    {
        public string mensagem { get; set; }
    }
}
