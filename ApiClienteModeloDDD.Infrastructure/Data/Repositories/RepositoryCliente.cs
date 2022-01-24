using ApiClienteModeloDDD.Domain.Models;
using ApiClienteModeloDDD.Domain.Core.Interfaces.Repositories;
using ApiClienteModeloDDD.Infrastructure.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ApiClienteModeloDDD.Application.DTOs;
using System;

namespace ApiClienteModeloDDD.Infrastructure.Data.Repositories
{
    public class RepositoryCliente : RepositoryBase<Cliente>, IRepositoryCliente
    {
        private readonly Context _context;
        public RepositoryCliente(Context context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Cliente>> GetAll()
        {   
            var result = _context.Clientes.Include(x => x.Endereco).AsEnumerable();
            return await Task.FromResult(result);
        }

        public override async Task<Cliente> GetById(int id)
        {
            var result = _context.Clientes.Include(x => x.Endereco).Where(a => a.Id == id).FirstOrDefault();
            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<Cliente>> GetByNome(string nome)
        {
            var result = _context.Clientes.Include(x => x.Endereco).Where(a => a.Nome.Contains(nome)).ToList();
            return await Task.FromResult(result);
        }

        public override async Task Update(int id, Cliente clienteRequest)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (clienteRequest.Nome != null)
                cliente.Nome = clienteRequest.Nome;
            if (clienteRequest.Sobrenome != null)
                cliente.Sobrenome = clienteRequest.Sobrenome;
            if (clienteRequest.CPF != null)
                cliente.CPF = clienteRequest.CPF;
            if (clienteRequest.DataNascimento != DateTime.MinValue)
                cliente.DataNascimento = clienteRequest.DataNascimento;
            if (clienteRequest.EnderecoId != 0)
                cliente.EnderecoId = clienteRequest.EnderecoId;
            await _context.SaveChangesAsync();
        }

    }
}
