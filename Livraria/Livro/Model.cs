using System;

namespace Livraria.Livro
{
    public class Model : Interface
    {
        public string ISBN { get; set; }
        public string Autor { get ; set ; }
        public string Nome { get ; set ; }
        public decimal Preco { get ; set ; }
        public DateTime PublicacaoData { get ; set ; }
        public byte[] CapaImagemConteudo { get ; set ; }
    }
}
