using Libreria.Backend.Data;
using Libreria.Backend.Repository;
using Libreria.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Backend.RepositoryImpl
{
    public class RepositoryLibroImpl : IRepositoryLibro
    {
        private readonly LibreriaContext _context;

        public RepositoryLibroImpl(LibreriaContext context) 
        {
            _context = context; 
        }

        //Listar
        public List<Libro> Get()
        {
            try
            {
                return _context.Libros.ToList();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("No se pudo registrar el libro. Verifique los datos del autor."+ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Guardar
        public void Add(Libro libro)
        {
            try
            {
                _context.Libros.Add(libro);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception((ex.Message));
            }
        }
    }
}
