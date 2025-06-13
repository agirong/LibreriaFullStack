using Libreria.Frontend.DTOs.Libro;
using Libreria.Frontend.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace Libreria.Frontend.Services
{
    public class LibroServiceImpl : ILibroService   
    {
        private readonly HttpClient _httpClient;

        public LibroServiceImpl(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponseDTO<List<LibroDTO>>?> GetLibrosAsync(string? busqueda = null)
        {
            try
            {
                string url = "api/Libros";
                if (!string.IsNullOrWhiteSpace(busqueda)) 
                {
                    url += $"?busqueda={Uri.EscapeDataString(busqueda)}";
                }
                return await _httpClient.GetFromJsonAsync<ApiResponseDTO<List<LibroDTO>>>(url);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error de conexión HTTP: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en LibroService.GetLibrosAsync: {ex.Message}");
                throw;
            }
        }

        public async Task PostLibroAsync(CrearLibroDTO crearLibro)
        {
            try
            {
                string json = JsonSerializer.Serialize(crearLibro);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync("api/Libros", content);
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseString);
                }
                else 
                {
                    Console.WriteLine("Error: " + response.StatusCode);
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error de conexión HTTP : {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en LibroService.GetLibrosAsync: {ex.Message}");
                throw;
            }
        }
    }
}
