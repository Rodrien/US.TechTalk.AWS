using Microsoft.AspNetCore.Mvc;
using US.TechTalk.AWS.API.Contracts;
using US.TechTalk.AWS.API.Mapping;
using US.TechTalk.AWS.API.Services.Interfaces;

namespace US.TechTalk.AWS.API.Controllers
{
    [ApiController]
    public class UrudatosController(IUrudatosService urudatosService) : ControllerBase
    {
        private readonly IUrudatosService _urudatosService = urudatosService;

        [HttpPost("urudatos")]
        public async Task<IActionResult> Create([FromBody] UrudatoRequest request)
        {
            var urudato = request.ToUrudato ();

            await _urudatosService.CreateAsync(urudato);

            var urudatoResponse = urudato.ToUrudatoResponse();

            return CreatedAtAction("Get", new { id = urudatoResponse.Id }, urudatoResponse);
        }

        [HttpDelete("urudatos/{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deleted = await _urudatosService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("urudatos")]
        public async Task<IActionResult> GetAll()
        {
            var urudatos = await _urudatosService.GetAllAsync();

            return Ok(urudatos);
        }

        [HttpGet("urudatos/{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var urudato = await _urudatosService.GetAsync(id);

            if (urudato is null)
            {
                return NotFound();
            }

            var urudatoResponse = urudato.ToUrudatoResponse();
            return Ok(urudatoResponse);
        }
    }
}
