using AppAngular.Server.Utils;
using Libreria.Backend.DTOs.Libro;
using Libreria.Backend.Models;
using Libreria.Backend.Repository;
using Libreria.Backend.Service;
using System.Collections.Generic;

namespace Libreria.Backend.ServiceImpl
{
    public class ServiceLibroImpl : IServiceLibro
    {
        private readonly IRepositoryLibro _repositoryLibro;

        GeneralResponse generalResponse = new GeneralResponse();
        public ServiceLibroImpl(IRepositoryLibro repositoryLibro) 
        {
            _repositoryLibro = repositoryLibro; 
        }

        public GeneralResponse ListarLibros()
        {
            try
            {
                List<LibroDTO> libros = _repositoryLibro.Get()
                    .Select(l => new LibroDTO
                    {
                        LibroID = l.LibroID,
                        Titulo = l.Titulo,
                        Anio = l.Anio,
                        Genero = l.Genero,
                        Editorial = l.Editorial,
                        Paginas = l.Paginas,
                        AutorID = l.AutorID,
                        //NombreAutor = l.Autor.Nombre // Accede a la propiedad Nombre del Autor
                    }).ToList();

                if (libros.Count() > 0)
                {
                    generalResponse = GeneralResponseFn.responseGeneral(Constantes.CODIGO_EXITO, Constantes.MENSAJE_OK, libros);
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

        public GeneralResponse RegistrarLibro(LibroDTO libro)
        {
            try
            {
                Libro libroDB = new Libro
                {
                    Titulo = libro.Titulo,
                    Anio = libro.Anio,
                    Genero = libro.Genero,
                    Editorial = libro.Editorial,
                    Paginas = libro.Paginas,
                    AutorID = libro.AutorID,
                };
                _repositoryLibro.Add(libroDB);
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
