using Libreria.Frontend.DTOs.Libro;
using Libreria.Frontend.DTOs.Autor;
using Libreria.Frontend.Models;

namespace Libreria.Frontend.Services
{
    public interface ILibroService
    {
        Task<ApiResponseDTO<List<LibroDTO>>?> GetLibrosAsync();
    }
}
