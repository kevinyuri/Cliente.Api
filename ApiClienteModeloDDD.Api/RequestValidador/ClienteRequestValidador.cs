using ApiClienteModeloDDD.Application.DTOs;
using ApiClienteModeloDDD.Domain.Models;
using FluentValidation;

namespace ApiClienteModeloDDD.Api.ClienteValidador
{
    public class ClienteRequestValidador : AbstractValidator<ClienteRequest>
    {
        public ClienteRequestValidador()
        {
            RuleFor(x => x.Nome).NotEmpty()
                .WithMessage("O campo Nome não pode ser vazio");
            RuleFor(x => x.Sobrenome).NotEmpty()
                .WithMessage("O campo Sobrenome não pode ser vazio");
            RuleFor(x => x.DataNascimento).NotEmpty()
                .WithMessage("O campo DataNascimento não pode ser vazio");
            RuleFor(x => x.CPF).NotEmpty()
                .WithMessage("O campo CPF não pode ser vazio");
            RuleFor(x => x.CPF).Length(11)
                .WithMessage("Insira um CPF válido de 11 dígitos.");
        }
    }
}
