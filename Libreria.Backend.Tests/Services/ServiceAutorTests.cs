using Libreria.Backend.DTOs.Autor;
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
        private readonly Mock<IRepositoryAutor> _mockAutorRepository;
        private readonly ServiceAutorImpl _sut;

        public ServiceAutorTests()
        {
            _mockAutorRepository = new Mock<IRepositoryAutor>();
            _sut = new ServiceAutorImpl(_mockAutorRepository.Object); 
        }
  
    }
}
