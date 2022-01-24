using ApiClienteModeloDDD.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiClienteModeloDDD.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryCliente : IRepositoryBase<Cliente>
    {
        Task<IEnumerable<Cliente>> GetByNome(string nome);
    }
}
