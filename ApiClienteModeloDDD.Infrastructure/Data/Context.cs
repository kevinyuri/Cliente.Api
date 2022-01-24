using ApiClienteModeloDDD.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiClienteModeloDDD.Infrastructure.Data
{
    public class Context : DbContext
    {
        public Context()
        {

        }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity => entity.HasKey(e => new { e.Id }));
            modelBuilder.Entity<Cliente>()
                .HasOne(e => e.Endereco)
                .WithMany(t => t.Clientes)
                .HasForeignKey(a => a.EnderecoId);

            modelBuilder.Entity<Endereco>(entity => entity.HasKey(e => new { e.Id }));
            modelBuilder.Entity<Endereco>()
                .HasMany(t => t.Clientes);
        }

    }


}
