using ApiClienteModeloDDD.Domain.Core.Interfaces.Repositories;
using ApiClienteModeloDDD.Domain.Core.Interfaces.Services;
using ApiClienteModeloDDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiClienteModeloDDD.Domain.Service
{
    public class ServiceEndereco : ServiceBase<Endereco>, IServiceEndereco
    {
        private readonly IRepositoryEndereco _repositoryEndereco;

        public ServiceEndereco(IRepositoryEndereco repositoryEndereco)
            : base(repositoryEndereco)
        {
            _repositoryEndereco = repositoryEndereco;
        }


    }
}
