using ApiClienteModeloDDD.Domain.Core.Interfaces.Repositories;
using ApiClienteModeloDDD.Domain.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiClienteModeloDDD.Domain.Service
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }
        public async Task PostAsync(TEntity obj)
        {
            await _repository.PostAsync(obj);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<TEntity> GetById(int id)
        {   
            return await _repository.GetById(id);
        }

        public async Task Update(int id, TEntity obj)
        {
            await _repository.Update(id, obj);
        }
        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
