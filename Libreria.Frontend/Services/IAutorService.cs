using Libreria.Frontend.DTOs.Autor;
using Libreria.Frontend.Models;

namespace Libreria.Frontend.Services
{
    public interface IAutorService
    {
        Task<ApiResponseDTO<List<AutorDTO>>?> GetAutorsAsync();
    }
}
