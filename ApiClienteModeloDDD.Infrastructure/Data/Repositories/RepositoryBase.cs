using ApiClienteModeloDDD.Application.DTOs;
using ApiClienteModeloDDD.Domain.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClienteModeloDDD.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly Context _context;
        //List<TEntity> clientes = new List<TEntity>();
        
        public RepositoryBase(Context context)
        {
            _context = context;
        }

        public async Task PostAsync(TEntity obj)
        {
            await _context.Set<TEntity>().AddAsync(obj);
            await _context.SaveChangesAsync();
        }


        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var result = _context.Set<TEntity>().AsEnumerable();
            return await Task.FromResult(result);
        }

        public virtual Task<TEntity> GetById(int id)
        {
            var result = _context.Set<TEntity>().Find(id);
            return Task.FromResult(result);
        }

        public async Task Delete(int id)
        {
            var cliente = await _context.Set<TEntity>().FindAsync(id);
            _context.Set<TEntity>().Remove(cliente);
            _context.SaveChanges();
        }

        
        public virtual async Task Update(int id, TEntity obj)
        {

            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            /*try
            {
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }*/
        }
    }
}
