namespace Livraria.WebApi.Controllers.Livro.Get.Atributo.Filtro
{
    public class Model
    {
        public String.Model ISBN { get; set; }
        public String.Model Autor { get; set; }
        public String.Model Nome { get; set; }
        public Decimal.Model Preco { get; set; }
        public DateTime.Model PublicacaoData { get; set; }
    }
}
