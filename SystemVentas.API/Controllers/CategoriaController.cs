using Microsoft.AspNetCore.Mvc;
using SystemVentas.Application.Contract;
using SystemVentas.Application.DTos.Categoria;

namespace SystemVentas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            this.categoriaService = categoriaService;
        }

        [HttpGet("ShowCategory")]
        public IActionResult Get()
        {
            var result = this.categoriaService.Get();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("ShowCategoryById")]
        public IActionResult Get(int id)
        {
            var result = this.categoriaService.GetById(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("ShowCategoryByInactive")]
        public IActionResult GetInactive()
        {
            var result = this.categoriaService.GetInactive();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveCategory")]
        public IActionResult Post([FromBody] CategoriaAddDTo categoriaAdd)
        {
            var result = this.categoriaService.Save(categoriaAdd);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdateCategory")]
        public IActionResult Put([FromBody] CategoriaUpdateDTo categoriaUpdate)
        {
            var result = this.categoriaService.Update(categoriaUpdate);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("RemoveCategory")]
        public IActionResult Delete(CategoriaRemoveDTo categoriaRemove)
        {
            var result = this.categoriaService.Remove(categoriaRemove);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
