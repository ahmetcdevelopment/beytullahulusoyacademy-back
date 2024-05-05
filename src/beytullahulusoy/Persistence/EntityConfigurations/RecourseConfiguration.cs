using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RecourseConfiguration : IEntityTypeConfiguration<Recourse>
{
    public void Configure(EntityTypeBuilder<Recourse> builder)
    {
        builder.ToTable("Recourses").HasKey(r => r.Id);

        builder.Property(r => r.Id).HasColumnName("Id").IsRequired();
        builder.Property(r => r.FirstName).HasColumnName("FirstName");
        builder.Property(r => r.LastName).HasColumnName("LastName");
        builder.Property(r => r.SizeM).HasColumnName("SizeM");
        builder.Property(r => r.WeightKg).HasColumnName("WeightKg");
        builder.Property(r => r.BirthDate).HasColumnName("BirthDate");
        builder.Property(r => r.Gender).HasColumnName("Gender");
        builder.Property(r => r.PhoneNumber).HasColumnName("PhoneNumber");
        builder.Property(r => r.Address).HasColumnName("Address");
        builder.Property(r => r.RecourseStatus).HasColumnName("RecourseStatus");
        builder.Property(r => r.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(r => r.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(r => r.DeletedDate).HasColumnName("DeletedDate");

        builder.Property(x => x.FirstName).HasMaxLength(100);
        builder.Property(x => x.LastName).HasMaxLength(100);
        builder.Property(x => x.PhoneNumber).HasMaxLength(16);
        builder.Property(x => x.Address).HasMaxLength(200);

        builder.HasQueryFilter(r => !r.DeletedDate.HasValue);
    }
}