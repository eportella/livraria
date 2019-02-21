using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Livraria.Test.WebApi
{
    [TestClass]
    public class Livro
    {
        [TestMethod, ExpectedException(typeof(Exception.Model))]
        public void CRUD()
        {
            var livro = new Livraria.Livro.Model
            {
                Nome = "Memórias Póstumas de Brás Cubas",
                ISBN = "9788538076902",
                Autor = "Machado de Assis",
                CapaImagemConteudo = new byte[] { },
                Preco = 16.52M,
                PublicacaoData = new System.DateTime(1882, 01, 01)
            };

            Assert.IsTrue(Livraria.WebApi.Controllers.Livro.Post.Service.Call(livro).Result.mensagem == null);

            Assert.IsTrue(Livraria.WebApi.Controllers.Livro.Get.Service.Call(new Livraria.WebApi.Controllers.Livro.Get.Model()).Result.resultado.Any(), "Created & Read");

            livro.Preco = 20.00M;

            Assert.IsTrue(Livraria.WebApi.Controllers.Livro.Put.Service.Call(livro).Result.mensagem == null);

            Assert.IsTrue(Livraria.WebApi.Controllers.Livro.Get.Service.Call(new Livraria.WebApi.Controllers.Livro.Get.Model()).Result.resultado.SingleOrDefault().Preco == 20.00M, "Update");

            Assert.IsTrue(Livraria.WebApi.Controllers.Livro.Delete.Service.Call(livro).Result.mensagem == null);

            Assert.IsTrue(Livraria.WebApi.Controllers.Livro.Get.Service.Call(new Livraria.WebApi.Controllers.Livro.Get.Model()).Result.resultado.SingleOrDefault() == null, "Delete");
        }

        [TestMethod, ExpectedException(typeof(Exception.Model))]
        public void RestricaoCadastroDoisLivrosComMesmoISBNAtualizacaoInexistenteExclusaoInexistente()
        {
            var livro = new Livraria.Livro.Model
            {
                Nome = "Memórias Póstumas de Brás Cubas",
                ISBN = "9788538076902",
                Autor = "Machado de Assis",
                CapaImagemConteudo = new byte[] { },
                Preco = 16.52M,
                PublicacaoData = new System.DateTime(1882, 01, 01)
            };

            var msg = Livraria.WebApi.Controllers.Livro.Put.Service.Call(livro).Result.mensagem;
            Assert.IsTrue(msg.Contains("9788538076902"));

            Livraria.WebApi.Controllers.Livro.Post.Service.Call(livro).Wait();
            msg = Livraria.WebApi.Controllers.Livro.Post.Service.Call(livro).Result.mensagem;

            Assert.IsTrue(msg.Contains("9788538076902"));

            Livraria.WebApi.Controllers.Livro.Delete.Service.Call(livro).Wait();
            msg = Livraria.WebApi.Controllers.Livro.Delete.Service.Call(livro).Result.mensagem;
            Assert.IsTrue(msg.Contains("9788538076902"));
        }
    }
}
