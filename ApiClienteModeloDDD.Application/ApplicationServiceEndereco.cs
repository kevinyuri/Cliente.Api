using ApiClienteModeloDDD.Application.DTOs;
using ApiClienteModeloDDD.Application.Interfaces;
using ApiClienteModeloDDD.Domain.Core.Interfaces.Repositories;
using ApiClienteModeloDDD.Domain.Core.Interfaces.Services;
using ApiClienteModeloDDD.Domain.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiClienteModeloDDD.Application
{
    public class ApplicationServiceEndereco : IApplicationServiceEndereco
    {
        private readonly IServiceEndereco _serviceEndereco;
        private readonly IMapper _mapper;
        private readonly IAddressProvider _addressProvider;


        public ApplicationServiceEndereco(IServiceEndereco serviceEndereco, IMapper mapper, IAddressProvider addressProvider)
        {
            _serviceEndereco = serviceEndereco;
            _mapper = mapper;
            _addressProvider = addressProvider;
        }
        public async Task PostAsync(EnderecoDto enderecoDto)
        {
            await _serviceEndereco.PostAsync(_mapper.Map<Endereco>(enderecoDto));
        }

        public EnderecoDto PostViaCep(string cep)
        {
            var endereco = _addressProvider.PostViaCep(cep);
            return endereco;
        }

        public async Task<IEnumerable<EnderecoResponse>> GetAll()
        {
            var enderecos = await _serviceEndereco.GetAll();
            var enderecosDto = _mapper.Map<IEnumerable<EnderecoResponse>>(enderecos);
            return enderecosDto;
        }

        public async Task<EnderecoResponse> GetById(int id)
        {
            var endereco = await _serviceEndereco.GetById(id);
            var enderecoDto = _mapper.Map<EnderecoResponse>(endereco);
            return enderecoDto;
        }

        public async Task Delete(int id)
        {
            await _serviceEndereco.Delete(id);
        }

        public async Task Update(int id, EnderecoDtoPut enderecoDto)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDto);
            await _serviceEndereco.Update(id, endereco);
        }
    }
}
