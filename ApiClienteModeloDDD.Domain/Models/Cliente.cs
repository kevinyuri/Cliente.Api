using System;

namespace ApiClienteModeloDDD.Domain.Models
{
    public class Cliente : Base
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
