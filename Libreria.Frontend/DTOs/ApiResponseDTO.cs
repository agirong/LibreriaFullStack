namespace Libreria.Frontend.Models
{
    public class ApiResponseDTO<T>
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
