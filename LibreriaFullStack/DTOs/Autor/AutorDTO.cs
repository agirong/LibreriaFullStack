using Libreria.Backend.DTOs.Libro;
using System.ComponentModel.DataAnnotations;

namespace Libreria.Backend.DTOs.Autor
{
    public class AutorDTO
    {
        public int AutorId { get; set; }  

        [Required, StringLength(100)]
        public string Nombre { get; set; } = null!;

        [Required, DataType(DataType.Date)]
        public DateTime FhNacimiento { get; set; }

        [StringLength(50)]  
        public string Ciudad { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        public ICollection<LibroDTO>? Libros { get; set; }
    }
}
