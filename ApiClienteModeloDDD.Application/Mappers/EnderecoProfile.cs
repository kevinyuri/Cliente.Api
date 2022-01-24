using ApiClienteModeloDDD.Application.DTOs;
using ApiClienteModeloDDD.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClienteModeloDDD.Application.Mappers
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            this.SetupInbound();
            this.SetupOutbound();
        }

        public void SetupInbound()
        {
            CreateMap<EnderecoDto, Endereco>();
            CreateMap<EnderecoDtoPut, Endereco>();
        }

        public void SetupOutbound()
        {
            CreateMap<Endereco, EnderecoResponse>();
        }
    }
}
