using FluentAssertions;
using Libreria.Backend.DTOs.Libro;
using Libreria.Backend.Models;
using Libreria.Backend.Repository;
using Libreria.Backend.ServiceImpl;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Backend.Tests.Services
{
    public class ServiceLibroTests
    {
        private readonly Mock<IRepositoryLibro> _mockLibroRepository;
        private readonly Mock<IRepositoryAutor> _mockAutorRepository;
        private readonly ServiceLibroImpl _servicioTest;

        public ServiceLibroTests() 
        {
            _mockLibroRepository = new Mock<IRepositoryLibro>();
            _mockAutorRepository = new Mock<IRepositoryAutor>(); 
            _servicioTest = new ServiceLibroImpl(_mockLibroRepository.Object, _mockAutorRepository.Object);
        }

        [Fact]
        public void ListarLibros_CuandoHayDatos_DevuelveListaDeLibros()
        {
            // ARRANGE
            var librosDtoDesdeRepo = new List<LibroDTO>
            {
                 new LibroDTO { idLibro = 1, titulo = "Cien años de soledad", nombreAutor = "G. García Márquez" },
                 new LibroDTO { idLibro = 2, titulo = "1984", nombreAutor = "George Orwell" }
            };
            _mockLibroRepository.Setup(repo => repo.Get()).Returns(librosDtoDesdeRepo);

            // ACT 
            var resultadoGeneral = _servicioTest.ListarLibros();

            // ASSERT 
            resultadoGeneral.Should().NotBeNull();
            resultadoGeneral.Status.Should().Be(200);
            var listaDeLibros = (List<LibroDTO>)resultadoGeneral.Data;
            listaDeLibros.Should().HaveCount(2);
            listaDeLibros[0].titulo.Should().Be("Cien años de soledad");
            listaDeLibros[0].nombreAutor.Should().Be("G. García Márquez");
        }

        [Fact]
        public void ListarLibros_CuandoNoHayDatos_DevuelveListaVacia()
        {
            // ARRANGE
            _mockLibroRepository.Setup(repo => repo.Get()).Returns(new List<LibroDTO>());

            // ACT
            var resultadoGeneral = _servicioTest.ListarLibros();

            // ASSERT
            resultadoGeneral.Should().NotBeNull();
            resultadoGeneral.Status.Should().Be(200);
            var listaDeLibros = (List<LibroDTO>)resultadoGeneral.Data;
            listaDeLibros.Should().BeEmpty();
        }

        [Fact]
        public void RegistrarLibro_CuandoDatosSonValidos_LlamaAlRepositorioYDevuelveExito()
        {
            // ARRANGE
            var crearLibroDto = new CrearLibroDTO
            {
                titulo = "Fahrenheit 451",
                anio = 1953,
                genero = "Ciencia Ficción",
                editorial = "Minotauro",
                paginas = 249,
                IdAutor = 3
            };

            _mockAutorRepository.Setup(repo => repo.GetById(3)).Returns(new Autor { AutorId = 3, Nombre = "Ray Bradbury" });
            _mockLibroRepository.Setup(repo => repo.Add(It.IsAny<Libro>()));

            _mockLibroRepository
            .Setup(repo => repo.Get())
            .Returns(new List<LibroDTO>()); 

            _mockLibroRepository
            .Setup(repo => repo.Add(It.IsAny<Libro>()));

            // ACT
            var resultadoGeneral = _servicioTest.RegistrarLibro(crearLibroDto);

            // ASSERT
            resultadoGeneral.Should().NotBeNull();
            resultadoGeneral.Status.Should().Be(200);

            var libroEnRespuesta = (CrearLibroDTO)resultadoGeneral.Data;
            libroEnRespuesta.titulo.Should().Be("Fahrenheit 451");
            
            // Verificar los datos.
            _mockAutorRepository.Verify(repo => repo.GetById(3), Times.Once);
            _mockLibroRepository.Verify(repo => repo.Add(It.IsAny<Libro>()), Times.Once);
        }
    }
}
