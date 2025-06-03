using Libreria.Frontend.Models;
using System.Net.Http.Json;

namespace Libreria.Frontend.Services
{
    public class LibroServiceImpl : ILibroService   
    {
        private readonly HttpClient _httpClient;

        public LibroServiceImpl(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse<List<Libro>>?> GetLibrosAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ApiResponse<List<Libro>>>("api/Libros");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Error de conexión: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en LibroService.GetLibrosAsync: {ex.Message}");
                return null;
            }
        }
    }
}
