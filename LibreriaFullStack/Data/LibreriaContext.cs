using Libreria.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Backend.Data
{
    public class LibreriaContext : DbContext
    {
        public LibreriaContext(DbContextOptions<LibreriaContext> options)
            : base(options)
        {
        }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autors { get; set; }
    }
}
