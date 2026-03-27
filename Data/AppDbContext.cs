using BarbeariaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BarbeariaApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define que a coluna Preco terá no máximo 18 dígitos, sendo 2 após a vírgula
            modelBuilder.Entity<ServiceModel>()
                .Property(s => s.Preco)
                .HasPrecision(18, 2);
        }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<ServiceModel> Servicos { get; set; }
        public DbSet<AgendamentoModel> Agendamentos { get; set; }
    }
}
