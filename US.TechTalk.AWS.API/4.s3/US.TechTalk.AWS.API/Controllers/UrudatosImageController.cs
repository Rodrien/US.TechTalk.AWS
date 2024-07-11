using Amazon.S3;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using US.TechTalk.AWS.API.Services.Interfaces;

namespace US.TechTalk.AWS.API.Controllers
{
    [ApiController]
    public class UrudatosImageController(IUrudatosImageService urudatosImageService) : ControllerBase
    {
        private readonly IUrudatosImageService _urudatosImageService = urudatosImageService;

        [HttpPost("urudatos/{id:guid}/image")]
        public async Task<IActionResult> Upload([FromRoute] Guid id,
        [FromForm(Name = "Data")] IFormFile file)
        {
            var response = await _urudatosImageService.UploadImageAsync(id, file);
            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("urudatos/{id:guid}/image")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            try
            {
                var response = await _urudatosImageService.GetImageAsync(id);
                return File(response.ResponseStream, response.Headers.ContentType);
            }
            catch (AmazonS3Exception ex) when (ex.Message is "The specified key does not exist.")
            {
                return NotFound();
            }
        }

        [HttpDelete("urudatos/{id:guid}/image")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _urudatosImageService.DeleteImageAsync(id);
            return response.HttpStatusCode switch
            {
                HttpStatusCode.NoContent => Ok(),
                HttpStatusCode.NotFound => NotFound(),
                _ => BadRequest()
            };
        }
    }
}
