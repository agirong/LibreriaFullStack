﻿using Libreria.Backend.DTOs.Autor;
using FluentAssertions;
using Libreria.Backend.Models;
using Libreria.Backend.ServiceImpl;
using Libreria.Backend.Service;
using Libreria.Backend.RepositoryImpl;
using Libreria.Backend.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libreria.Backend.Utils;

namespace Libreria.Backend.Tests.Services
{
    public class ServiceAutorTests
    {
        //Mock para simular el repositotry
        private readonly Mock<IRepositoryAutor> _mockRepositoryAutor;
        private readonly ServiceAutorImpl _servicioTest;

        public ServiceAutorTests()
        {
            _mockRepositoryAutor = new Mock<IRepositoryAutor>();
            _servicioTest = new ServiceAutorImpl(_mockRepositoryAutor.Object); 
        }

        [Fact]
        public void ListarAutores_Deberia_DevolverRespuestaExitosaConAutores_CuandoExistenAutores()
        {
            // ARRANGE
            var autoresDesdeDb = new List<Autor>
            {
                new Autor { AutorId = 1, Nombre = "Gabriel García Márquez" },
                new Autor { AutorId = 2, Nombre = "George Orwell" }
            };

            _mockRepositoryAutor.Setup(repo => repo.Get()).Returns(autoresDesdeDb);

            // ACT 
            var resultado = _servicioTest.ListarAutores();

            // ASSERT
            resultado.Should().NotBeNull();
            resultado.Status.Should().Be(Constantes.CODIGO_EXITO);
            var listaDeAutores = (List<AutorDTO>)resultado.Data;
            listaDeAutores[0].nombre.Should().Be("Gabriel García Márquez");
            listaDeAutores[1].idAutor.Should().Be(2);
        }

        [Fact]
        public void ListarAutores_Deberia_DevolverRespuestaExitosaConListaVacia_CuandoNoExistenAutores()
        {
            // ARRANGE
            _mockRepositoryAutor.Setup(repo => repo.Get()).Returns(new List<Autor>());

            // ACT
            var resultado = _servicioTest.ListarAutores();

            // ASSERT
            resultado.Should().NotBeNull();
            resultado.Status.Should().Be(Constantes.CODIGO_EXITO);
            resultado.Data.Should().NotBeNull();
            var listaDeAutores = (List<AutorDTO>)resultado.Data;
            listaDeAutores.Should().BeEmpty();
        }

        [Fact]
        public void RegistrarAutor_Deberia_LlamarAlRepositorioYDevolverExito_CuandoDatosSonValidos()
        {
            // ARRANGE
            var crearAutorDto = new CrearAutorDTO
            {
                nombre = "Isabel Allende",
                ciudad = "Lima",
                email = "isabel@gmail.com",
                fhNacimiento = new DateTime(1942, 8, 2)
            };

            var autorCreado = new Autor
            {
                AutorId = 10,
                Nombre = crearAutorDto.nombre,
                Ciudad = crearAutorDto.ciudad,
                Email = crearAutorDto.email,
                FhNacimiento = crearAutorDto.fhNacimiento
            };

            _mockRepositoryAutor.Setup(repo => repo.Add(It.IsAny<Autor>()));

            // ACT 
            var resultadoGeneral = _servicioTest.RegistrarAutor(crearAutorDto);

            // ASSERT
            resultadoGeneral.Should().NotBeNull();
            resultadoGeneral.Status.Should().Be(Constantes.CODIGO_EXITO);

            // Verificar los datos.
            var autorEnRespuesta = (CrearAutorDTO)resultadoGeneral.Data;
            autorEnRespuesta.Should().NotBeNull();
            autorEnRespuesta.nombre.Should().Be("Isabel Allende");

            _mockRepositoryAutor.Verify(repo => repo.Add(It.IsAny<Autor>()), Times.Once);
        }
    }
}
