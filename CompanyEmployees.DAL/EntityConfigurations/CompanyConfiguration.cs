using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyEmployees.DAL.EntityConfigurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("CompanyId")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("newsequentialid()")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar(60)")
                .IsRequired();

            builder.Property(p => p.Address)
                .HasColumnName("Address")
                .HasColumnType("nvarchar(60)")
                .IsRequired();

            builder.Property(p => p.Country)
                .HasColumnName("Country")
                .HasColumnType("nvarchar(MAX)");

            builder.HasMany(x => x.Employees)
                .WithOne(b => b.Company)
                .HasForeignKey(b => b.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
