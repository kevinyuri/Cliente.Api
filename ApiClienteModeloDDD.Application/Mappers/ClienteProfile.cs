using ApiClienteModeloDDD.Application.DTOs;
using ApiClienteModeloDDD.Domain.Models;
using AutoMapper;

namespace ApiClienteModeloDDD.Application.Mappers
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            this.SetupInbound();
            this.SetupOutbound();
        }

        public void SetupInbound()
        {
            CreateMap<ClienteRequest, Cliente>();
            CreateMap<ClienteRequestPut, Cliente>();
        }

        public void SetupOutbound()
        {

            CreateMap<Cliente, ClienteResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                    .ForMember(dest => dest.NomeCompleto, opt => opt.MapFrom(x => x.Nome + " " + x.Sobrenome))
                    .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(x => x.DataNascimento.ToShortDateString()))
                    .ForMember(dest => dest.Endereco, opt => opt.MapFrom(x => $"{x.Endereco.Logradouro}, Bairro {x.Endereco.Bairro}, {x.Endereco.Cidade}/{x.Endereco.UF}"));
        }
    }
}
