namespace Livraria.EntityFramework.Livro
{
    public class Model
    {
        internal Model() : base() { }
        public long Id { get; set; }
        public string ISBN { get; set; }
        public Autor.Model Autor { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public System.DateTime PublicacaoData { get; set; }
        public byte[] CapaImagemConteudo { get; set; }
    }
}