using System.ComponentModel.DataAnnotations;

namespace Libreria.Frontend.DTOs.Autor
{
    public class AutorDTO
    {
        public int idAutor { get; set; }
        public string nombre { get; set; }
        public DateTime fhNacimiento { get; set; }
        public string? ciudad { get; set; } = null!;
        public string? email { get; set; } = null!;
    }
}
