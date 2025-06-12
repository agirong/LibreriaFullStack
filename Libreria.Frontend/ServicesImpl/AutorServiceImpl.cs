using Libreria.Frontend.DTOs.Autor;
using Libreria.Frontend.Models;
using System.Net.Http.Json;
using System.Text.Json;

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

        public async Task PostAutorsAsync(CrearAutorDTO crearAutor)
        {
            try
            {
                string json = JsonSerializer.Serialize(crearAutor);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync("api/Autor", content);
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
