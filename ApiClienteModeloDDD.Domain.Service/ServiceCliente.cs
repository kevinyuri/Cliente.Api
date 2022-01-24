using ApiClienteModeloDDD.Application.DTOs;
using ApiClienteModeloDDD.Domain.Core.Interfaces.Repositories;
using ApiClienteModeloDDD.Domain.Core.Interfaces.Services;
using ApiClienteModeloDDD.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClienteModeloDDD.Domain.Service
{
    public class ServiceCliente : ServiceBase<Cliente>, IServiceCliente
    {
        private readonly IRepositoryCliente _repositoryCliente;

        public ServiceCliente(IRepositoryCliente repositoryCliente, IMapper mapper)
            : base(repositoryCliente)
        {
            _repositoryCliente = repositoryCliente;
        }

        public async Task<IEnumerable<Cliente>> GetByNome(string nome)
        {
            return await _repositoryCliente.GetByNome(nome);
        }

    }
}
