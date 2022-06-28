using CompanyEmployees.DAL.EntityConfigurations;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployess.DAL
{
    public class ExternalClientContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public ExternalClientContext(DbContextOptions<ExternalClientContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
        }
    }
}
