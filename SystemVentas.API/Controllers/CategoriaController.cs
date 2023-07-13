using Microsoft.AspNetCore.Mvc;
using SystemVentas.Infrastructure.Interfaces;

namespace SystemVentas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository categoriasRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            this.categoriasRepository = categoriaRepository;
        }

        [HttpGet("ShowCategory")]
        public IActionResult Get()
        {
            var cat = this.categoriasRepository.GetAllCategories();
            return Ok(cat);
        }

        [HttpGet("ShowCategoryById")]
        public IActionResult Get(int id)
        {
            var cat = this.categoriasRepository.GetCategoryById(id);
            return Ok(cat);
        }

        [HttpGet("ShowCategoryByActive")]
        public IActionResult GetActive()
        {
            var cat = this.categoriasRepository.GetCategoryByActive();
            return Ok(cat);
        }

        [HttpGet("ShowCategoryByInactive")]
        public IActionResult GetInactive()
        {
            var cat = this.categoriasRepository.GetCategoryByInactuve();
            return Ok(cat);
        }

        [HttpPost("SaveCategory")]
        public IActionResult Post([FromBody] string value)
        {
            return Ok();
        }

        [HttpPut("UpdateCategory")]
        public IActionResult Put([FromBody] string value)
        {
            return Ok();
        }

        [HttpDelete("RemoveCategory")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
