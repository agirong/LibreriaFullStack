using Libreria.Frontend.DTOs.Autor;
using Libreria.Frontend.Models;
using System.Net.Http.Json;

namespace Libreria.Frontend.Services
{
    public class AutorServiceImpl : IAutorService
    {
        private readonly HttpClient _httpClient;

        public AutorServiceImpl(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponseDTO<List<AutorDTO>>?> GetAutorsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ApiResponseDTO<List<AutorDTO>>>("api/Autor");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error de conexión: {ex.Message}");
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
