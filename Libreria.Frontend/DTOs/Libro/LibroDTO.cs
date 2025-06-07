namespace Libreria.Frontend.DTOs.Libro
{
    public class LibroDTO
    {
        public int idLibro { get; set; }
        public string titulo { get; set; }
        public int anio { get; set; }
        public string? genero { get; set; }
        public string? editorial { get; set; }
        public int paginas { get; set; }
        public string nombreAutor { get; set; }
    }
}
