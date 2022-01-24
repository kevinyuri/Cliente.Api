using ApiClienteModeloDDD.Application.DTOs;
using ApiClienteModeloDDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClienteModeloDDD.Application.Interfaces
{
    public interface IApplicationServiceEndereco
    {
        Task PostAsync(EnderecoDto enderecoDto);
        Task<EnderecoResponse> GetById(int id);
        Task<IEnumerable<EnderecoResponse>> GetAll();
        Task Update(int id, EnderecoDtoPut enderecoDto);
        Task Delete(int id);
        EnderecoDto PostViaCep(string cep);
    }
}
