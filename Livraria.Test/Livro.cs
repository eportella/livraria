using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Livraria.Test
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
            Livraria.Livro.Service.Create(livro).Wait();

            Assert.IsTrue(Livraria.Livro.Service.Read(f => f.Where(Livraria.Livro.Expression.ISBNHas(livro))).Any(), "Created & Read");

            livro.Preco = 20.00M;

            Livraria.Livro.Service.Update(livro);

            Assert.IsTrue(Livraria.Livro.Service.Read(f => f.Where(Livraria.Livro.Expression.ISBNHas(livro)).Where(w => w.Preco == 20.00M)).Any(), "Update");

            Livraria.Livro.Service.Delete(livro);

            Assert.IsFalse(Livraria.Livro.Service.Read(f => f.Where(Livraria.Livro.Expression.ISBNHas(livro))).Any(), "Delete");
        }

        [TestMethod]
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

            Assert.ThrowsExceptionAsync<Exception.Model>(() => Livraria.Livro.Service.Update(livro)).Wait();

            Livraria.WebApi.Controllers.Livro.Post.Service.Call(livro).Wait();
            Assert.ThrowsExceptionAsync<Exception.Model>(() => Livraria.Livro.Service.Create(livro)).Wait();

            Livraria.WebApi.Controllers.Livro.Delete.Service.Call(livro).Wait();
            Assert.ThrowsExceptionAsync<Exception.Model>(() => Livraria.Livro.Service.Delete(livro)).Wait();
        }
    }
}
