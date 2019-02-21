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
        public async Task<Envelope.Model<IEnumerable<Livraria.Livro.Interface>>> Get([FromQuery] Livro.Get.Model model) =>
            await Livro.Get.Service.Call(model);

        [HttpPost]
        public async Task<Envelope.Model> Post([FromBody]Livraria.Livro.Model model) =>
            await Livro.Post.Service.Call(model);

        [HttpPut]
        public async Task<Envelope.Model> Put([FromBody]Livraria.Livro.Model model) =>
            await Livro.Put.Service.Call(model);

        [HttpDelete]
        public async Task<Envelope.Model> Delete([FromBody]Livraria.Livro.Model model) =>
            await Livro.Delete.Service.Call(model);
    }
}