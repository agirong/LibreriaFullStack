namespace Libreria.Backend.Utils
{
    public class GeneralResponse
    {
        public int Status { get; set; } 
        public string? Message { get; set; } 
        public object? Data { get; set; }
    }
}
