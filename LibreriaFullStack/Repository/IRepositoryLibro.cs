using Libreria.Backend.DTOs.Libro;
using Libreria.Backend.Models;

namespace Libreria.Backend.Repository
{
    public interface IRepositoryLibro
    {
        public List<LibroDTO> Get(string? busqueda= null);

        public void Add(Libro libro);
    }
}
