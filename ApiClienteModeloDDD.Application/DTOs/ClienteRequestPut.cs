using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClienteModeloDDD.Application.DTOs
{
    public class ClienteRequestPut
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public int EnderecoId { get; set; }
    }
}
