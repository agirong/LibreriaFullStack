using Libreria.Backend.Data;
using Libreria.Backend.Repository;
using Libreria.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Libreria.Backend.DTOs.Libro;

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
        public List<LibroDTO> Get(string? busqueda = null)
        {
            try
            {
                var query = _context.Libros
                            .Include(libro => libro.Autor)
                            .AsQueryable();

                // Cuando se recibe una busqueda
                if (!string.IsNullOrWhiteSpace(busqueda))
                {
                    string busquedaEnMinusculas = busqueda.ToLower();

                    query = query.Where(libro =>
                        libro.Titulo.ToLower().Contains(busquedaEnMinusculas) ||
                        libro.Autor.Nombre.ToLower().Contains(busquedaEnMinusculas) ||
                        libro.Anio.ToString().Contains(busqueda)
                    );
                }

                return query
                .Select(libro => new LibroDTO
                {
                    idLibro = libro.LibroID,
                    titulo = libro.Titulo,
                    anio = libro.Anio,
                    genero = libro.Genero,
                    editorial = libro.Editorial,
                    paginas = libro.Paginas,
                    nombreAutor = libro.Autor.Nombre
                })
                .ToList();
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
            catch (DbUpdateException ex)
            {
                throw new Exception("No se pudo registrar el libro. Verifique los datos del autor." + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
