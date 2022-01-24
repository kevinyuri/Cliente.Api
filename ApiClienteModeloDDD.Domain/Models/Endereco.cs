using System;
using System.Collections.Generic;

namespace ApiClienteModeloDDD.Domain.Models
{
    public class Endereco : Base
    {
        public int Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public virtual IEnumerable<Cliente>Clientes { get; set; }
       
    }
}
