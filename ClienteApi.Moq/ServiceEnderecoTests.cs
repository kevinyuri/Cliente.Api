using ApiClienteModeloDDD.Domain.Core.Interfaces.Repositories;
using ApiClienteModeloDDD.Domain.Models;
using ApiClienteModeloDDD.Domain.Service;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ClienteApi.Moq
{
    public class ServiceEnderecoTests
    {
        private readonly ServiceEndereco _sut; //system under test
        private readonly Mock<IRepositoryEndereco> _repositoryEnderecoMock = new Mock<IRepositoryEndereco>();


        public ServiceEnderecoTests()
        {
            _sut = new ServiceEndereco(_repositoryEnderecoMock.Object);
        }

        [Fact]

        public async Task GetAll_ShouldReturnTwoAddress_WhenTwoAddressExist()
        {
            //Arrange
            var enderecos = new List<Endereco>();
            enderecos.Add(new Endereco() { Id = 1 });
            enderecos.Add(new Endereco() { Id = 2 });

            _repositoryEnderecoMock.Setup(x => x.GetAll()).ReturnsAsync(enderecos);

            //Act

            var result = await _sut.GetAll();

            //Assert

            Assert.Equal(2, result.Count());
            _repositoryEnderecoMock.VerifyAll();
        }


        [Fact]
        public async Task GetById_ShouldReturnAddress_WhenAdressExists()
        {

            // Arrange
            const int id = 10;
            var cep = "60525-280";
            var logradouro = "Rua Antônio Ivo";
            var complemento = "de 1261/1262 ao fim";
            var bairro = "João XXIII";
            var cidade = "Fortaleza";
            var uf = "CE";

            var endereco = (new Endereco()
            {
                Id = id,
                Cep = cep,
                Logradouro = logradouro,
                Complemento = complemento,
                Bairro = bairro,
                Cidade = cidade,
                UF = uf
            });

            _repositoryEnderecoMock.Setup(x => x.GetById(id)).ReturnsAsync(endereco);


            // Act
            var result = await _sut.GetById(id);

            // Assert
            Assert.Equal(id, result.Id);
            Assert.Equal(cep, result.Cep);
            Assert.Equal(logradouro, result.Logradouro);
            Assert.Equal(complemento, result.Complemento);
            Assert.Equal(bairro, result.Bairro);
            Assert.Equal(cidade, result.Cidade);
            Assert.Equal(uf, result.UF);
        }


        [Fact]
        public void Post_ShouldCreateACustomer_WhenCustomerExists()
        {
            // Arrange

            const int id = 10;
            var cep = "60525-280";
            var logradouro = "Rua Antônio Ivo";
            var complemento = "de 1261/1262 ao fim";
            var bairro = "João XXIII";
            var cidade = "Fortaleza";
            var uf = "CE";

            var endereco = (new Endereco()
            {
                Id = id,
                Cep = cep,
                Logradouro = logradouro,
                Complemento = complemento,
                Bairro = bairro,
                Cidade = cidade,
                UF = uf
            });

            _repositoryEnderecoMock.Setup(repo => repo.PostAsync(endereco)).Verifiable();

            // Act
            var result = _sut.PostAsync(endereco);

            // Assert

            _repositoryEnderecoMock.Verify();
        }

        [Fact]
        public async Task Put_ShouldUpdateCustomer_WhenCustomerExists()
        {
            // Arrange

            const int id = 10;
            var cep = "60525-280";
            var logradouro = "Rua Antônio Ivo";
            var complemento = "de 1261/1262 ao fim";
            var bairro = "João XXIII";
            var cidade = "Fortaleza";
            var uf = "CE";

            var endereco = (new Endereco()
            {
                Id = id,
                Cep = cep,
                Logradouro = logradouro,
                Complemento = complemento,
                Bairro = bairro,
                Cidade = cidade,
                UF = uf
            });

            _repositoryEnderecoMock.Setup(repo => repo.Update(id, endereco)).Verifiable();

            // Act
            await _sut.Update(id, endereco);

            // Assert
            _repositoryEnderecoMock.Verify();

        }

        [Fact]
        public async Task Delete_ShouldDeleteCustomer_WhenCustomerExists()
        {
            // Arrange

            _repositoryEnderecoMock.Setup(repo => repo.Delete(It.IsAny<int>())).Verifiable();

            // Act
            await _sut.Delete(3);

            // Assert
            _repositoryEnderecoMock.Verify();
        }
    }
}
