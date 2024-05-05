using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SponsorConfiguration : IEntityTypeConfiguration<Sponsor>
{
    public void Configure(EntityTypeBuilder<Sponsor> builder)
    {
        builder.ToTable("Sponsors").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.CompanyName).HasColumnName("CompanyName");
        builder.Property(s => s.Logo).HasColumnName("Logo");
        builder.Property(s => s.StartDate).HasColumnName("StartDate");
        builder.Property(s => s.EndDate).HasColumnName("EndDate");
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");

        builder.Property(x => x.CompanyName).HasMaxLength(150);
        builder.Property(x => x.Logo).HasMaxLength(100);

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
    }
}