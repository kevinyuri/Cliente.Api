using ApiClienteModeloDDD.Domain.Models;
using System;

namespace ApiClienteModeloDDD.Application.DTOs
{
    public class ClienteResponse
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
    }
}
