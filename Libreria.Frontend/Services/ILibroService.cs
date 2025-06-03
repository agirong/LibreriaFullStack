using Libreria.Frontend.Models;

namespace Libreria.Frontend.Services
{
    public interface ILibroService
    {
        Task<ApiResponse<List<Libro>>?> GetLibrosAsync();
    }
}
