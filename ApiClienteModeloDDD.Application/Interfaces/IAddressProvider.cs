using ApiClienteModeloDDD.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClienteModeloDDD.Application.Interfaces
{
    public interface IAddressProvider
    {
        EnderecoDto PostViaCep(string cep);
    }
}
