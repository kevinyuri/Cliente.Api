using ApiClienteModeloDDD.Domain.Core.Interfaces.Repositories;
using ApiClienteModeloDDD.Domain.Models;
using ApiClienteModeloDDD.Domain.Service;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ClienteApi.Moq
{
    public class ServiceClienteTests
    {
        private readonly ServiceCliente _sut; //system under test
        private readonly Mock<IRepositoryCliente> _repositoryClienteMock = new Mock<IRepositoryCliente>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        public ServiceClienteTests()
        {
            _sut = new ServiceCliente(_repositoryClienteMock.Object, _mapperMock.Object);
        }

        [Fact]

        public async Task GetAll_ShouldReturnTwoClientes_WhenTwoClientesExist()
        {
            //Arrange
            var clientes = new List<Cliente>();
            clientes.Add(new Cliente() { Id = 1 });
            clientes.Add(new Cliente() { Id = 2 });

            _repositoryClienteMock.Setup(x => x.GetAll()).ReturnsAsync(clientes);

            //Act

            var result = await _sut.GetAll();

            //Assert

            Assert.Equal(2, result.Count());
            _repositoryClienteMock.VerifyAll();
        }


        [Fact]
        public async Task GetById_ShouldReturnCustomer_WhenCustomerExists()
        {

            // Arrange
            const int id = 10;
            var nome = "Carlos";
            var sobrenome = "Almeida";
            var cpf = "234235235";
            var dataNascimento = DateTime.Now;

            var cliente = (new Cliente()
            {
                Id = id,
                Nome = nome,
                Sobrenome = sobrenome,
                CPF = cpf,
                DataNascimento = dataNascimento
            });

            _repositoryClienteMock.Setup(x => x.GetById(id)).ReturnsAsync(cliente);


            // Act
            var result = await _sut.GetById(id);

            // Assert
            Assert.Equal(id, result.Id);
            Assert.Equal(nome, result.Nome);
            Assert.Equal(cpf, result.CPF);
            Assert.Equal(dataNascimento, result.DataNascimento);
        }


        [Fact]

        public async Task GetByNome_ShouldReturnCustomer_WhenCustomerExists()
        {
            var clientes = new List<Cliente>();

            // Arrange
            const int id = 10;
            var nome = "Carlos";
            var sobrenome = "Almeida";
            var cpf = "234235235";
            var dataNascimento = DateTime.Now;


            clientes.Add(new Cliente()
            {
                Id = id,
                Nome = nome,
                Sobrenome = sobrenome,
                CPF = cpf,
                DataNascimento = dataNascimento
            });

            _repositoryClienteMock.Setup(x => x.GetByNome(nome)).ReturnsAsync(clientes);


            // Act
            var result = await _sut.GetByNome(nome);

            // Assert
            var reservation = Assert.IsType<List<Cliente>>(result);
            Assert.Equal(id, reservation[0].Id);
            Assert.Equal(nome, reservation[0].Nome);
            Assert.Equal(cpf, reservation[0].CPF);
            Assert.Equal(dataNascimento, reservation[0].DataNascimento);
        }

        [Fact]
        public async Task Post_ShouldCreateACustomer_WhenCustomerExists()
        {
            // Arrange

            const int id = 10;
            var nome = "Carlos";
            var sobrenome = "Almeida";
            var cpf = "234235235";
            var dataNascimento = DateTime.Now;

            var cliente = (new Cliente()
            {
                Id = id,
                Nome = nome,
                Sobrenome = sobrenome,
                CPF = cpf,
                DataNascimento = dataNascimento
            });

            _repositoryClienteMock.Setup(repo => repo.PostAsync(It.IsAny<Cliente>())).Verifiable();

            // Act
            await _sut.PostAsync(cliente);

            // Assert
            _repositoryClienteMock.Verify();

        }

        [Fact]
        public async Task Put_ShouldUpdateCustomer_WhenCustomerExists()
        {
            // Arrange

            const int id = 10;
            var nome = "Carlos";
            var sobrenome = "Almeida";
            var cpf = "234235235";
            var dataNascimento = DateTime.Now;

            var cliente = (new Cliente()
            {
                Id = id,
                Nome = nome,
                Sobrenome = sobrenome,
                CPF = cpf,
                DataNascimento = dataNascimento
            });

            _repositoryClienteMock.Setup(repo => repo.Update(id, cliente)).Verifiable();

            // Act
            await _sut.Update(id,cliente);

            // Assert
            _repositoryClienteMock.Verify();

        }

        [Fact]
        public async Task Delete_ShouldDeleteCustomer_WhenCustomerExists()
        {
            // Arrange

            _repositoryClienteMock.Setup(repo => repo.Delete(It.IsAny<int>())).Verifiable();

            // Act
            await _sut.Delete(3);

            // Assert
            _repositoryClienteMock.Verify();
        }

    }
}
