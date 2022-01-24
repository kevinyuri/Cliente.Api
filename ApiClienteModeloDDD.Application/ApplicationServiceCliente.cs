using ApiClienteModeloDDD.Application.DTOs;
using ApiClienteModeloDDD.Application.Interfaces;
using ApiClienteModeloDDD.Domain.Core.Interfaces.Services;
using ApiClienteModeloDDD.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiClienteModeloDDD.Application
{
    public class ApplicationServiceCliente : IApplicationServiceCliente
    {
        private readonly IServiceCliente _serviceCliente;
        private readonly IMapper _mapper;

        public ApplicationServiceCliente(IServiceCliente serviceCliente, IMapper mapper)
        {
            _serviceCliente = serviceCliente;
            _mapper = mapper;
        }

        public async Task PostAsync(ClienteRequest cliente)
        {
            await _serviceCliente.PostAsync(_mapper.Map<Cliente>(cliente));

        }

        public async Task<IEnumerable<ClienteResponse>> GetAll()
        {
            var clientes = await _serviceCliente.GetAll();
            var clientesResponse = _mapper.Map<IEnumerable<ClienteResponse>>(clientes);
            return clientesResponse;
        }

        public async Task<ClienteResponse> GetById(int id)
        {
            var cliente = await _serviceCliente.GetById(id);
            return _mapper.Map<ClienteResponse>(cliente);
        }

        public async Task<IEnumerable<ClienteResponse>> GetByNome(string nome)
        {   
            var clientes = await _serviceCliente.GetByNome(nome);
            var clientesResponse = _mapper.Map<IEnumerable<ClienteResponse>>(clientes);
            return clientesResponse;
        }

        public async Task Delete(int id)
        {
            await _serviceCliente.Delete(id);
        }

        public async Task Update(int id, ClienteRequestPut clienteRequest)
        {
            await _serviceCliente.Update(id, _mapper.Map<Cliente>(clienteRequest));
        }
    }
}
