namespace Libreria.Frontend.Models
{
    public class Libro
    {
        public int idLibro { get; set; }
        public string titulo { get; set; }
        public int anio { get; set; }
        public string? genero { get; set; }
        public string? editorial { get; set; }
        public int paginas { get; set; }
        public int idAutor { get; set; }
    }
}
