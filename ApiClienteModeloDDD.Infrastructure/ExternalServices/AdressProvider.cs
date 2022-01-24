using ApiClienteModeloDDD.Application.DTOs;
using ApiClienteModeloDDD.Application.Interfaces;
using ApiClienteModeloDDD.Domain.Core.Interfaces.Repositories;
using ApiClienteModeloDDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiClienteModeloDDD.Infrastructure.ExternalServices
{
    public class AdressProvider : IAddressProvider
    {
        private HttpClient _httpClient;

        public AdressProvider()
        {
            _httpClient = new HttpClient();
        }

        public EnderecoDto PostViaCep(string cep)
        {
            var url = $"https://viacep.com.br/ws/{cep}/json";

            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                var response = _httpClient.Send(request);
                string result = response.Content.ReadAsStringAsync().Result;

                var enderecoViaCep = JsonSerializer.Deserialize<EnderecoViaCep>(result);

                EnderecoDto endereco = new EnderecoDto()
                {
                    Cep = enderecoViaCep.cep,
                    Logradouro = enderecoViaCep.logradouro,
                    Bairro = enderecoViaCep.bairro,
                    Complemento = enderecoViaCep.complemento,
                    Cidade = enderecoViaCep.localidade,
                    UF = enderecoViaCep.uf
                };

                return endereco;
            }

        }
    }
}
