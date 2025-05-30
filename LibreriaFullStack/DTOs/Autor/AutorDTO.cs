using Libreria.Backend.DTOs.Libro;
using System.ComponentModel.DataAnnotations;

namespace Libreria.Backend.DTOs.Autor
{
    public class AutorDTO
    {
        public int idAutor { get; set; }  

        [Required(ErrorMessage = "nombre es obligatorio"), StringLength(100)]
        public string nombre { get; set; } = null!;

        [Required(ErrorMessage = "fhNacimiento es obligatorio"), DataType(DataType.Date)]
        public DateTime fhNacimiento { get; set; }

        [StringLength(50)]  
        public string? ciudad { get; set; } = null!;
        [StringLength(50)]
        public string? email { get; set; } = null!;

        //public ICollection<LibroDTO>? Libros { get; set; }
    }
}
