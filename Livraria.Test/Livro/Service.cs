using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Test.Livro
{
    [TestClass]
    public class Service
    {
        [TestMethod]
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
            Livraria.Livro.Create.Service.Call(livro).Wait();

            Assert.IsTrue(Livraria.Livro.Read.Service.Call(f => f.Where(Livraria.Livro.Expression.ISBNHas(livro))).Any(), "Created & Read");

            livro.Preco = 20.00M;

            Livraria.Livro.Update.Service.Call(livro);

            Assert.IsTrue(Livraria.Livro.Read.Service.Call(f => f.Where(Livraria.Livro.Expression.ISBNHas(livro)).Where(w => w.Preco == 20.00M)).Any(), "Update");

            Livraria.Livro.Delete.Service.Call(livro);

            Assert.IsFalse(Livraria.Livro.Read.Service.Call(f => f.Where(Livraria.Livro.Expression.ISBNHas(livro))).Any(), "Delete");
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

            Assert.ThrowsExceptionAsync<Exception.Model>(() => Livraria.Livro.Update.Service.Call(livro)).Wait();

            Livraria.WebApi.Controllers.Livro.Post.Service.Call(livro).Wait();
            Assert.ThrowsExceptionAsync<Exception.Model>(() => Livraria.Livro.Create.Service.Call(livro)).Wait();

            Livraria.WebApi.Controllers.Livro.Delete.Service.Call(livro).Wait();
            Assert.ThrowsExceptionAsync<Exception.Model>(() => Livraria.Livro.Delete.Service.Call(livro)).Wait();
        }

        [TestMethod]
        public void ConsultasComFiltroEOrdenadas()
        {
            Assert.IsTrue(Livraria.WebApi.Controllers.Livro.Post.Service.Call(new Livraria.Livro.Model
            {
                Nome = "Memórias Póstumas de Brás Cubas",
                ISBN = "9788538076902",
                Autor = "Machado de Assis",
                CapaImagemConteudo = new byte[] { },
                Preco = 16.52M,
                PublicacaoData = new System.DateTime(1882, 01, 01)
            }).Result.mensagem == null);

            Assert.IsTrue(Livraria.WebApi.Controllers.Livro.Post.Service.Call(new Livraria.Livro.Model
            {
                Nome = "Dom Casmurro",
                ISBN = "9788572322645",
                Autor = "Machado de Assis",
                CapaImagemConteudo = new byte[] { },
                Preco = 15.90M,
                PublicacaoData = new System.DateTime(1899, 01, 01)
            }).Result.mensagem == null);

            Assert.IsTrue(Livraria.WebApi.Controllers.Livro.Post.Service.Call(new Livraria.Livro.Model
            {
                Nome = "Macunaíma",
                ISBN = "9788520923771",
                Autor = "Mario De Andrade",
                CapaImagemConteudo = new byte[] { },
                Preco = 29.99M,
                PublicacaoData = new System.DateTime(1928, 01, 01)
            }).Result.mensagem == null);

            Assert.IsTrue(Livraria.WebApi.Controllers.Livro.Get.Service.Call(new Livraria.WebApi.Controllers.Livro.Get.Model
            {

            }).Result.resultado.First().Nome == "Memórias Póstumas de Brás Cubas");

            Assert.IsTrue(Livraria.WebApi.Controllers.Livro.Get.Service.Call(new Livraria.WebApi.Controllers.Livro.Get.Model
            {
                Atributo = new Livraria.WebApi.Controllers.Livro.Get.Atributo.Model
                {
                    Filtro = new Livraria.WebApi.Controllers.Livro.Get.Atributo.Filtro.Model
                    {
                        ISBN = new Livraria.WebApi.Controllers.Livro.Get.Atributo.Filtro.String.Model
                        {
                            Contem = "9788520923771"
                        }
                    }
                }
            }).Result.resultado.Single().ISBN == "9788520923771");

            Assert.IsTrue(!Livraria.WebApi.Controllers.Livro.Get.Service.Call(new Livraria.WebApi.Controllers.Livro.Get.Model
            {
                Atributo = new Livraria.WebApi.Controllers.Livro.Get.Atributo.Model
                {
                    Filtro = new Livraria.WebApi.Controllers.Livro.Get.Atributo.Filtro.Model
                    {
                        ISBN = new Livraria.WebApi.Controllers.Livro.Get.Atributo.Filtro.String.Model
                        {
                            Contem = "9788520923779"
                        }
                    }
                }
            }).Result.resultado.Any());

            Assert.IsTrue(Livraria.WebApi.Controllers.Livro.Get.Service.Call(new Livraria.WebApi.Controllers.Livro.Get.Model
            {
                Atributo = new Livraria.WebApi.Controllers.Livro.Get.Atributo.Model
                {
                    Filtro = new Livraria.WebApi.Controllers.Livro.Get.Atributo.Filtro.Model
                    {
                        Nome = new Livraria.WebApi.Controllers.Livro.Get.Atributo.Filtro.String.Model
                        {
                            Contem = "Dom"
                        }
                    }
                }
            }).Result.resultado.Single().Nome == "Dom Casmurro");

            Assert.IsTrue(Livraria.WebApi.Controllers.Livro.Get.Service.Call(new Livraria.WebApi.Controllers.Livro.Get.Model
            {
                Atributo = new Livraria.WebApi.Controllers.Livro.Get.Atributo.Model
                {
                    Filtro = new Livraria.WebApi.Controllers.Livro.Get.Atributo.Filtro.Model
                    {
                        Autor = new Livraria.WebApi.Controllers.Livro.Get.Atributo.Filtro.String.Model
                        {
                            Contem = "Machado de Assis"
                        }
                    }
                }
            }).Result.resultado.Count() == 2);

            Assert.IsTrue(Livraria.WebApi.Controllers.Livro.Get.Service.Call(new Livraria.WebApi.Controllers.Livro.Get.Model
            {
                Atributo = new Livraria.WebApi.Controllers.Livro.Get.Atributo.Model
                {
                    Filtro = new Livraria.WebApi.Controllers.Livro.Get.Atributo.Filtro.Model
                    {
                        Preco = new Livraria.WebApi.Controllers.Livro.Get.Atributo.Filtro.Decimal.Model
                        {
                            Acima = 10,
                            Abaixo = 20
                        }
                    }
                }
            }).Result.resultado.Count() == 2);

            Assert.IsTrue(Livraria.WebApi.Controllers.Livro.Get.Service.Call(new Livraria.WebApi.Controllers.Livro.Get.Model
            {
                Atributo = new Livraria.WebApi.Controllers.Livro.Get.Atributo.Model
                {
                    Ordem = new Livraria.WebApi.Controllers.Livro.Get.Atributo.Ordem.Model
                    {
                        Direcao = 'D',
                        Nome = nameof(Livraria.Livro.Model.Preco)
                    }
                }
            }).Result.resultado.First().Preco == 29.99M);

            
            Task.WaitAll(Livraria.WebApi.Controllers.Livro.Get.Service.Call(null).Result.resultado.Select(item => Livraria.WebApi.Controllers.Livro.Delete.Service.Call(new Livraria.Livro.Model
            {
                ISBN = item.ISBN
            })).ToArray());


        }
    }
}
