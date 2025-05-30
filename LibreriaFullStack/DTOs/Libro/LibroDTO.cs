using System.ComponentModel.DataAnnotations;

namespace Libreria.Backend.DTOs.Libro
{
    public class LibroDTO
    {
        public int idLibro { get; set; }

        [Required(ErrorMessage = "El campo 'Título' es obligatorio."), StringLength(100)]
        public string titulo { get; set; }

        [Required(ErrorMessage = "El campo 'Año' es obligatorio."), Range(1,2100)]
        public int anio { get; set; }
        public string? genero { get; set; }
        public string? editorial { get; set; }

        [Required(ErrorMessage = "El número de páginas es obligatorio."), Range(1, int.MaxValue)]
        public int paginas { get; set; }

        [Required(ErrorMessage = "El campo 'Autor' es obligatorio."), Range(1, int.MaxValue)]
        public int idAutor { get; set; }
    }
}
