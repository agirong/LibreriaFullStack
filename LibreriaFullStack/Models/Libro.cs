using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Libreria.Backend.Models
{
    public class Libro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LibroID { get; set; }
        [Required]
        public string? Titulo { get; set; }
        public int Anio { get; set; }
        public string? Genero { get; set; }
        public string? Editorial { get; set; }
        public int Paginas { get; set; }
        public int AutorID { get; set; }

        [ForeignKey("AutorID")]
        public virtual Autor Autor { get; set; }
    }
}
