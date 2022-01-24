using ApiClienteModeloDDD.Api.ClienteValidador;
using ApiClienteModeloDDD.Api.RequestValidador;
using ApiClienteModeloDDD.Infrastructure.CrossCutting.IOC;
using ApiClienteModeloDDD.Infrastructure.Data;
using Autofac;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace ApiClienteModeloDDD.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ClienteRequestValidador>()); ;

            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<EnderecoRequestValidador>()); ;


            services.AddApiVersioning();
            services.AddApiVersioning(config =>
            {
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.ReportApiVersions = true;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiClienteModeloDDD.Api", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            

            var connection = Configuration["SqlConnection:SqlConnectionString"];
            services.AddDbContext<Context>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("ApiClienteModeloDDD.Api")));
            services.AddMemoryCache();

            /*var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ClienteProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);*/

        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ModuleIOC());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiClienteModeloDDD.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
