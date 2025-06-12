using System.ComponentModel.DataAnnotations;

namespace Libreria.Frontend.DTOs.Autor
{
    public class CrearAutorDTO
    {
        [Required(ErrorMessage = "Nombre es obligatorio"), StringLength(100)]
        public string nombre { get; set; } = null!;

        [Required(ErrorMessage = "Fecha de Nacimiento es obligatoria"), DataType(DataType.Date)]
        public DateTime? fhNacimiento { get; set; }

        [StringLength(50)]
        public string? ciudad { get; set; } = null!;
        [StringLength(50)]
        public string? email { get; set; } = null!;
    }
}
