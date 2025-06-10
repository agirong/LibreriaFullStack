using Libreria.Backend.Utils;
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
        private readonly IRepositoryAutor _repositoryAutor;

        GeneralResponse generalResponse = new GeneralResponse();
        public ServiceLibroImpl(IRepositoryLibro repositoryLibro, IRepositoryAutor repositoryAutor) 
        {
            _repositoryLibro = repositoryLibro; 
            _repositoryAutor = repositoryAutor;   
        }

        public GeneralResponse ListarLibros()
        {
            try
            {
                List<LibroDTO> libros = _repositoryLibro.Get()
                    .Select(l => new LibroDTO
                    {
                        idLibro = l.idLibro,
                        titulo = l.titulo,
                        anio = l.anio,
                        genero = l.genero,
                        editorial = l.editorial,
                        paginas = l.paginas,
                        nombreAutor = l.nombreAutor,
                        //NombreAutor = l.Autor.Nombre 
                    }).ToList();

                generalResponse = GeneralResponseFn.responseGeneral(Constantes.CODIGO_EXITO, Constantes.MENSAJE_OK, libros);
            }
            catch (Exception ex)
            {
                generalResponse = GeneralResponseFn.responseGeneral(Constantes.CODIGO_ERROR, Constantes.getMensaje(""), null);
            }
            return generalResponse; 
        }

        public GeneralResponse RegistrarLibro(CrearLibroDTO libro)
        {
            try
            {
                // Validar campos obligatorios
                if (string.IsNullOrWhiteSpace(libro.titulo) ||
                libro.anio <= 0 ||
                string.IsNullOrWhiteSpace(libro.genero) ||
                libro.paginas <= 0 ||
                libro.IdAutor <= 0)
                {
                    return GeneralResponseFn.responseGeneral(Constantes.CODIGO_ERROR, "Faltan campos obligatorios", null);
                }
                // Verificar existencia del autor 
                var autor = _repositoryAutor.GetById(libro.IdAutor);
                if (autor == null)
                {
                    return GeneralResponseFn.responseGeneral(Constantes.CODIGO_ERROR, "El autor ingresado no existe", null);
                }

                // Validación personalizada el año no puede ser futuro
                if (libro.anio > DateTime.Now.Year)
                {
                    return GeneralResponseFn.responseGeneral(Constantes.CODIGO_ERROR, "El año no puede ser en el futuro", null);
                }

                // Controlar número máximo de libros, ejemplo 15
                var totalLibros = _repositoryLibro.Get().Count();
                if (totalLibros >= 15)
                {
                    return GeneralResponseFn.responseGeneral(Constantes.CODIGO_ERROR, "Libreria llena. No puede registrar mas libros", null);
                }
                Libro libroDB = new Libro
                {
                    Titulo = libro.titulo,
                    Anio = libro.anio,
                    Genero = libro.genero,
                    Editorial = libro.editorial,
                    Paginas = libro.paginas,
                    AutorID = libro.IdAutor,
                };
                _repositoryLibro.Add(libroDB);
                generalResponse = GeneralResponseFn.responseGeneral(Constantes.CODIGO_EXITO, Constantes.MENSAJE_OK, libro);
            }
            catch (Exception ex)
            {
                generalResponse = GeneralResponseFn.responseGeneral(Constantes.CODIGO_ERROR, Constantes.getMensaje(ex.Message), null);
            }
            return generalResponse;
        }
    }
}
