using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Livraria.Test.Autor
{
    [TestClass]
    public class Service
    {
        [TestMethod]
        public void CUD()
        {
            var autor = "Machado de Assis";
                
            Livraria.Autor.Create.Service.Call(autor).Wait();

            Assert.IsTrue(
                Livraria.Autor.Read.Service.Call(
                    function: f => f.Where(Livraria.Autor.Expression.NomeHas(autor))
                )
                .Any(),
                "Created & Read");

            Livraria.Autor.Delete.Service.Call(autor);

            Assert.IsFalse(
                Livraria.Autor.Read.Service.Call(
                    function: f => f.Where(Livraria.Autor.Expression.NomeHas(autor))
                )
                .Any(), 
                "Delete");
        }

        [TestMethod]
        public void RestricaoCadastroDoisAutoresComMesmoNomeExclusaoInexistente()
        {
            var livro = "Machado de Assis";

            Livraria.Autor.Create.Service.Call(livro).Wait();
            Assert.ThrowsExceptionAsync<Exception.Model>(() => Livraria.Autor.Create.Service.Call(livro)).Wait();

            Livraria.Autor.Delete.Service.Call(livro).Wait();
            Assert.ThrowsExceptionAsync<Exception.Model>(() => Livraria.Autor.Delete.Service.Call(livro)).Wait();
        }
    }
}
