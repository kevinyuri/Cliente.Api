using ApiClienteModeloDDD.Application.DTOs;
using ApiClienteModeloDDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClienteModeloDDD.Application.Interfaces
{
    public interface IApplicationServiceCliente
    {
        Task PostAsync(ClienteRequest cliente);
        Task<ClienteResponse> GetById(int id);
        Task<IEnumerable<ClienteResponse>> GetByNome(string nome);
        Task<IEnumerable<ClienteResponse>> GetAll();
        Task Update(int id, ClienteRequestPut clienteRequest);
        Task Delete(int id);
    }
}
