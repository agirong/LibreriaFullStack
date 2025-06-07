using Libreria.Backend.Utils;
using Libreria.Backend.DTOs.Libro;

namespace Libreria.Backend.Service
{
    public interface IServiceLibro
    {
        public GeneralResponse ListarLibros();

        public GeneralResponse RegistrarLibro(CrearLibroDTO libro);
    }
}
