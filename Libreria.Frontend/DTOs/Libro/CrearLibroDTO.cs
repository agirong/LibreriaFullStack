using System.ComponentModel.DataAnnotations;

namespace Libreria.Frontend.DTOs.Libro
{
    public class CrearLibroDTO
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string titulo { get; set; }

        [System.ComponentModel.DataAnnotations.Required, Range(1, 2100)]
        public int anio { get; set; }
        public string? genero { get; set; }
        public string? editorial { get; set; }
        public int paginas { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un autor.")]
        public int? IdAutor { get; set; }
    }
}
