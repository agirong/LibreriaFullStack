using Libreria.Backend.Data;
using Libreria.Backend.Models;
using Libreria.Backend.Repository;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Backend.RepositoryImpl
{
    public class RepositoryAutorImpl: IRepositoryAutor
    {
        private readonly LibreriaContext _context;
        public RepositoryAutorImpl(LibreriaContext context) 
        {
            _context = context; 
        }

        //Listar
        public List<Autor> Get()
        {
            try
            {
                return _context.Autors.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Guardar
        public void Add(Autor autor)
        {
            try
            {
                _context.Autors.Add(autor);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("No se pudo registrar el Autor." + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
