using Libreria.Backend.Models;

namespace Libreria.Backend.Repository
{
    public interface IRepositoryLibro
    {
        public List<Libro> Get();

        public Libro GetById(int idAutor);

        public void Add(Libro libro);
    }
}
