using ApiClienteModeloDDD.Application.DTOs;
using ApiClienteModeloDDD.Domain.Core.Interfaces.Repositories;
using ApiClienteModeloDDD.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClienteModeloDDD.Infrastructure.Data.Repositories
{
    public class RepositoryEndereco : RepositoryBase<Endereco>, IRepositoryEndereco
    {
        private readonly Context _context;
        public RepositoryEndereco(Context context) : base(context)
        {
            _context = context;
        }

        public override async Task<Endereco> GetById(int id)
        {
            var result = _context.Enderecos.Include(x => x.Clientes).Where(a => a.Id == id).FirstOrDefault();
            return await Task.FromResult(result);
        }

        public override async Task<IEnumerable<Endereco>> GetAll()
        {
            var result = _context.Enderecos.Include(x => x.Clientes).AsEnumerable();
            return await Task.FromResult(result);
        }

        public override async Task Update(int id, Endereco enderecoRequest)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            if (enderecoRequest.Cep != null)
                endereco.Cep = enderecoRequest.Cep;
            if (enderecoRequest.Logradouro != null)
                endereco.Logradouro = enderecoRequest.Logradouro;
            if (enderecoRequest.UF != null)
                endereco.UF = enderecoRequest.UF;
            if (enderecoRequest.Complemento != null)
                endereco.Complemento = enderecoRequest.Complemento;
            if (enderecoRequest.Bairro != null)
                endereco.Bairro = enderecoRequest.Bairro;
            await _context.SaveChangesAsync();
        }

    }
}
