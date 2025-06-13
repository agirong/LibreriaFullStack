using Libreria.Backend.Utils;
using Libreria.Backend.DTOs.Libro;
using Libreria.Backend.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Libreria.Backend.Controllers.Libros
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly IServiceLibro _serviceLibro;

        GeneralResponse generalResponse = new GeneralResponse();
        public LibrosController(IServiceLibro serviceLibro) 
        {
            _serviceLibro = serviceLibro;         
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get([FromQuery] string? busqueda)
        {
            try
            {
                generalResponse = _serviceLibro.ListarLibros(busqueda);
                if (generalResponse.Status.Equals(Constantes.CODIGO_EXITO))
                {
                    return Ok(generalResponse);
                }
                else
                {
                    return BadRequest(generalResponse);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] CrearLibroDTO libro)
        {
            try
            {
                generalResponse = _serviceLibro.RegistrarLibro(libro);
                if (generalResponse.Status.Equals(Constantes.CODIGO_EXITO))
                {
                    return Ok(generalResponse);
                }
                else
                {
                    return BadRequest(generalResponse);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(Constantes.CODIGO_ERROR, ex.Message);
            }
        }
    }
}
