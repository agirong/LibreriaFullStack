namespace Libreria.Backend.DTOs.Libro
{
    public class LibroDTO
    {
        public int LibroID { get; set; }
        public string? Titulo { get; set; }
        public int Anio { get; set; }
        public string? Genero { get; set; }
        public string? Editorial { get; set; }
        public int Paginas { get; set; }

        // Aquí podrías incluir la información del autor si la necesitas
        // Por ejemplo, solo el nombre del autor o un DTO más pequeño para el autor.
        public int AutorID { get; set; }
        //public string? NombreAutor { get; set; } // Añadido para mostrar el nombre del autor
    }
}
