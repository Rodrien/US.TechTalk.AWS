using Microsoft.AspNetCore.Mvc;
using US.TechTalk.AWS.API.Contracts;
using US.TechTalk.AWS.API.Mapping;
using US.TechTalk.AWS.API.Services.Interfaces;

namespace US.TechTalk.AWS.API.Controllers
{
    [ApiController]
    public class UrudatosController : ControllerBase
    {
        private readonly IUrudatosService _urudatosService;

        public UrudatosController(IUrudatosService urudatosService)
        {
            _urudatosService = urudatosService;
        }

        public async Task<IActionResult> Create([FromBody] UrudatoRequest request)
        {
            var urudato = request.ToUrudato();

            await _urudatosService.CreateAsync(urudato);

            var urudatoResponse = urudato.ToUrudatoResponse();

            return CreatedAtAction("Get", new { id = urudatoResponse.Id }, urudatoResponse);
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
