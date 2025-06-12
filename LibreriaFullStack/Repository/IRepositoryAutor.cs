using Libreria.Backend.Models;

namespace Libreria.Backend.Repository
{
    public interface IRepositoryAutor
    {
        public List<Autor> Get();
        public Autor GetById(int idAutor);
        public void Add(Autor autor);
    }
}
