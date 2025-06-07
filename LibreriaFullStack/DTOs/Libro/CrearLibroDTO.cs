using System.ComponentModel.DataAnnotations;

namespace Libreria.Backend.DTOs.Libro
{
    public class CrearLibroDTO
    {
        [Required(ErrorMessage = "El Titulo es obligatorio."), StringLength(100)]
        public string titulo { get; set; }

        [Required(ErrorMessage = "El Año es obligatorio."), Range(1, 2100)]
        public int anio { get; set; }
        public string? genero { get; set; }
        public string? editorial { get; set; }
        public int paginas { get; set; }

        [Required(ErrorMessage = "El campo Autor es obligatorio."), Range(1, int.MaxValue, ErrorMessage ="Seleccione un autor valido.")]
        public int IdAutor { get; set; }
    }
}
