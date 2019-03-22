namespace Livraria.WebApi.Controllers.Envelope
{
    internal class Service
    {
        internal static Model<T> Create<T>(T resultado = default(T), string mensagem = default(string)) =>
            new Model<T>
            {
                mensagem = mensagem,
                resultado = resultado
            };

        internal static Model Create(string mensagem = default(string)) =>
            new Model()
            {
                mensagem = mensagem
            };

        internal static Model Create(Exception.Model exception) =>
            new Model()
            {
                mensagem = exception?.Message
            };
    }
}