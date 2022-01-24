using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClienteModeloDDD.Domain.Core.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task PostAsync(TEntity obj);
        Task Update(int id, TEntity obj);
        Task Delete(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);

    }
}
