namespace Livraria.Livro
{
    public interface Interface
    {
        string ISBN { get; set; }
        string Autor { get; set; }
        string Nome { get; set; }
        decimal Preco { get; set; }
        System.DateTime PublicacaoData { get; set; }
        byte[] CapaImagemConteudo { get; set; }
    }
}