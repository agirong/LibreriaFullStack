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
                List<AutorDTO> autor = _repositoryAutor.Get()
                    .Select(a => new AutorDTO
                    {
                        idAutor = a.AutorId,
                        nombre = a.Nombre,  
                        fhNacimiento = a.FhNacimiento,
                        ciudad = a.Ciudad,
                        email = a.Email,    
                    }).ToList();

                if (autor.Count() > 0)
                {
                    generalResponse = GeneralResponseFn.responseGeneral(Constantes.CODIGO_EXITO, Constantes.MENSAJE_OK, autor);
                }
                else
                {
                    generalResponse = GeneralResponseFn.responseGeneral(Constantes.CODIGO_NO_DATA, Constantes.MENSAJE_NO_DATA, null);
                }
            }
            catch (Exception ex)
            {
                generalResponse = GeneralResponseFn.responseGeneral(Constantes.CODIGO_ERROR, Constantes.getMensaje(""), null);
            }
            return generalResponse;
        }

        public GeneralResponse RegistrarAutor(AutorDTO autor)
        {
            try
            {                
                Autor autorDB = new Autor
                {
                    Nombre = autor.nombre,
                    FhNacimiento = autor.fhNacimiento,
                    Ciudad = autor.ciudad,
                    Email = autor.email,
                };
                _repositoryAutor.Add(autorDB);
                generalResponse = GeneralResponseFn.responseGeneral(Constantes.CODIGO_EXITO, Constantes.MENSAJE_OK, null);
            }
            catch (Exception ex)
            {
                generalResponse = GeneralResponseFn.responseGeneral(Constantes.CODIGO_ERROR, Constantes.getMensaje(ex.Message), null);
            }
            return generalResponse;
        }
    }
}
