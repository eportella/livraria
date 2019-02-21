namespace Livraria.EntityFramework.Livro
{
    public class Model
    {
        public long Id { get; set; }
        public string ISBN { get; set; }
        public string Autor { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public System.DateTime PublicacaoData { get; set; }
        public byte[] CapaImagemConteudo { get; set; }
    }
}