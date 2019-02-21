namespace Livraria.Exception
{
    public class Model : System.Exception
    {
        internal Model() : base() { }
        internal Model(string message) : base(message: message) { }
        internal Model(string message, System.Exception innerException) : base(message: message, innerException: innerException) { }
    }
}