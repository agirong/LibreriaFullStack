using Libreria.Backend.DTOs.Autor;
using Libreria.Backend.Utils;

namespace Libreria.Backend.Service
{
    public interface IServiceAutor
    {
        public GeneralResponse ListarAutores();
        public GeneralResponse RegistrarAutor(CrearAutorDTO autor);
    }
}
