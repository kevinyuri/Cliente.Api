using ApiClienteModeloDDD.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiClienteModeloDDD.Domain.Core.Interfaces.Services
{
    public interface IServiceCliente : IServiceBase<Cliente>
    {
        Task<IEnumerable<Cliente>> GetByNome(string nome);
    }
}
