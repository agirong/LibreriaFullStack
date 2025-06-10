using Libreria.Backend.DTOs.Autor;
using Libreria.Backend.Models;
using Libreria.Backend.Repository;
using Libreria.Backend.Service;
using Libreria.Backend.Utils;

namespace Libreria.Backend.ServiceImpl
{
    public class ServiceAutorImpl : IServiceAutor
    {
        private readonly IRepositoryAutor _repositoryAutor;
        GeneralResponse generalResponse = new GeneralResponse();
        public ServiceAutorImpl(IRepositoryAutor repositoryAutor) 
        {
            _repositoryAutor = repositoryAutor; 
        }

        public GeneralResponse ListarAutores()
        {
            try
            {
                List<AutorDTO> autorDto = _repositoryAutor.Get()
                    .Select(a => new AutorDTO
                    {
                        idAutor = a.AutorId,
                        nombre = a.Nombre,  
                        fhNacimiento = a.FhNacimiento,
                        ciudad = a.Ciudad,
                        email = a.Email,    
                    }).ToList();

                return GeneralResponseFn.responseGeneral(Constantes.CODIGO_EXITO, Constantes.MENSAJE_OK, autorDto);
            }
            catch (Exception ex)
            {
                generalResponse = GeneralResponseFn.responseGeneral(Constantes.CODIGO_ERROR, Constantes.getMensaje(""), null);
            }
            return generalResponse;
        }

        public GeneralResponse RegistrarAutor(CrearAutorDTO autor)
        {
            try
            {                
                Autor autorDB = new Autor
                {
                    Nombre = autor.nombre,
                    FhNacimiento = autor.fhNacimiento.ToUniversalTime(),
                    Ciudad = autor.ciudad,
                    Email = autor.email,
                };
                _repositoryAutor.Add(autorDB);
                generalResponse = GeneralResponseFn.responseGeneral(Constantes.CODIGO_EXITO, Constantes.MENSAJE_OK, autor);
            }
            catch (Exception ex)
            {
                generalResponse = GeneralResponseFn.responseGeneral(Constantes.CODIGO_ERROR, Constantes.getMensaje(ex.Message), null);
            }
            return generalResponse;
        }
    }
}
