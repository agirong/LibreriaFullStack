using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Libreria.Backend.Models
{
    public class Autor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AutorId { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime FhNacimiento { get; set; }
        public string Ciudad { get; set; } = null!;
        public string Email { get; set; } = null!;
        public virtual ICollection<Libro> Libros { get; set; } = null!;
    }
}
