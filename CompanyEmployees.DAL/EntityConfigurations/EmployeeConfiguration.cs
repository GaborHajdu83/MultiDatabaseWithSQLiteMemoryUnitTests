using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyEmployees.DAL.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("EmployeeId")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("newsequentialid()")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar(30)")
                .IsRequired();

            builder.Property(p => p.Age)
                .HasColumnName("Age")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Position)
                .HasColumnName("Position")
                .HasColumnType("nvarchar(20)")
                .IsRequired();

            builder.Property(p => p.CompanyId)
                .HasColumnName("CompanyId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.HasOne(x => x.Company)
                .WithMany(b => b.Employees)
                .HasForeignKey(b => b.CompanyId);
        }
    }
}
