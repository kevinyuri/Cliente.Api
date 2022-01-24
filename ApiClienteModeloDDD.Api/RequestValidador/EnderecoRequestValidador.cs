using ApiClienteModeloDDD.Application.DTOs;
using ApiClienteModeloDDD.Domain.Models;
using FluentValidation;

namespace ApiClienteModeloDDD.Api.RequestValidador
{
    public class EnderecoRequestValidador : AbstractValidator<EnderecoDto>
    {
        public EnderecoRequestValidador()
        {
            RuleFor(x => x.Logradouro).NotEmpty()
                .WithMessage("O campo Logradouro não pode ser vazio");
            RuleFor(x => x.Cep).NotEmpty()
                .WithMessage("O campo CEP não pode ser vazio");
            RuleFor(x => x.Bairro).NotEmpty()
                .WithMessage("O campo Bairro não pode ser vazio");
            RuleFor(x => x.UF).NotEmpty()
                .WithMessage("O campo UF não pode ser vazio");
        }
        
    }
}
