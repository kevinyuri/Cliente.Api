using ApiClienteModeloDDD.Application;
using ApiClienteModeloDDD.Application.DTOs;
using ApiClienteModeloDDD.Domain.Core.Interfaces.Services;
using ApiClienteModeloDDD.Domain.Models;
using AutoFixture;
using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Xunit;
using Assert = Xunit.Assert;

namespace ApiClienteModeloDDD.Tests
{
    [TestFixture]
    public class ApplicationServiceClienteTests
    {
        private static Fixture _fixture;
        private Mock<IServiceCliente> _serviceClienteMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _serviceClienteMock = new Mock<IServiceCliente>();
            _mapperMock = new Mock<IMapper>();
        }

        [Test]
        public void ApplicationServiceCliente_GetAll_ShouldReturnFiveClients()
        {
            //Arrange
            var clientes = _fixture.Build<Cliente>().CreateMany(5);
            var clientesDto = _fixture.Build<ClienteRequest>().CreateMany(5);

            _serviceClienteMock.Setup(x => x.GetAll()).Returns(clientes);
            _mapperMock.Setup(x => x.Map<IEnumerable<ClienteRequest>>(clientes)).Returns(clientesDto);

            var applicationServiceCliente = new ApplicationServiceCliente(_serviceClienteMock.Object, _mapperMock.Object);

            //Act
            var result = applicationServiceCliente.GetAll();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count());
            _serviceClienteMock.VerifyAll();
            _mapperMock.VerifyAll();
        }

    }

    
}
