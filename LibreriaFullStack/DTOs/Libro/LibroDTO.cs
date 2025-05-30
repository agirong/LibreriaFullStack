namespace Libreria.Backend.DTOs.Libro
{
    public class LibroDTO
    {
        public int idLibro { get; set; }
        public string? titulo { get; set; }
        public int anio { get; set; }
        public string? genero { get; set; }
        public string? editorial { get; set; }
        public int paginas { get; set; }

        // Aquí podrías incluir la información del autor si la necesitas
        // Por ejemplo, solo el nombre del autor o un DTO más pequeño para el autor.
        public int idAutor { get; set; }
        //public string? NombreAutor { get; set; } // Añadido para mostrar el nombre del autor
    }
}
