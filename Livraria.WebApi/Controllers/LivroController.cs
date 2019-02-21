using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livraria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Livraria.Livro.Interface>> Get([FromQuery] Livro.Get.Model model) =>
            await Task.Run(() => Livraria.Livro.Service.Read());

        [HttpPost]
        public async Task Post([FromBody]Livraria.Livro.Model model) =>
            await Livraria.Livro.Service.Create(model);

        [HttpPut]
        public async Task Put([FromBody] Livraria.Livro.Model model) =>
            await Livraria.Livro.Service.Update(model);

        [HttpDelete]
        public async Task Delete([FromBody] Livraria.Livro.Model model) =>
            await Livraria.Livro.Service.Delete(model);
    }
}