using Libreria.Backend.DTOs.Autor;
using Libreria.Backend.Service;
using Libreria.Backend.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Libreria.Backend.Controllers.Autores
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IServiceAutor _serviceAutor;        
        GeneralResponse generalResponse = new GeneralResponse();    
        public AutorController(IServiceAutor serviceAutor) 
        {
            _serviceAutor = serviceAutor;      
        }    

        // GET: api/<AutorController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                generalResponse = _serviceAutor.ListarAutores();
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

        // POST api/<AutorController>
        [HttpPost]
        public IActionResult Post([FromBody] CrearAutorDTO autor)
        {
            try
            {
                generalResponse = _serviceAutor.RegistrarAutor(autor);  
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
