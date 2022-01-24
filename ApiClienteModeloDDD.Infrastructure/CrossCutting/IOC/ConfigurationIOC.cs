using ApiClienteModeloDDD.Application;
using ApiClienteModeloDDD.Application.Interfaces;
using ApiClienteModeloDDD.Application.Mappers;
using ApiClienteModeloDDD.Domain.Core.Interfaces.Repositories;
using ApiClienteModeloDDD.Domain.Core.Interfaces.Services;
using ApiClienteModeloDDD.Domain.Service;
using ApiClienteModeloDDD.Infrastructure.Data.Repositories;
using ApiClienteModeloDDD.Infrastructure.ExternalServices;
using Autofac;
using AutoMapper;

namespace ApiClienteModeloDDD.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC
            builder.RegisterType<ApplicationServiceCliente>().As<IApplicationServiceCliente>();
            builder.RegisterType<ApplicationServiceEndereco>().As<IApplicationServiceEndereco>();

            builder.RegisterType<ServiceCliente>().As<IServiceCliente>();
            builder.RegisterType<ServiceEndereco>().As<IServiceEndereco>();

            builder.RegisterType<RepositoryCliente>().As<IRepositoryCliente>();
            builder.RegisterType<RepositoryEndereco>().As<IRepositoryEndereco>();

            builder.RegisterType<AdressProvider>().As<IAddressProvider>();


            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ClienteProfile());
                cfg.AddProfile(new EnderecoProfile());

            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();

            
        }

        #endregion IOC
    }
}
