using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
{
    public void Configure(EntityTypeBuilder<Announcement> builder)
    {
        builder.ToTable("Announcements").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.Picture).HasColumnName("Picture");
        builder.Property(a => a.Title).HasColumnName("Title");
        builder.Property(a => a.Text).HasColumnName("Text");
        builder.Property(a => a.PrivacyStatus).HasColumnName("PrivacyStatus");
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(x => x.Picture).HasMaxLength(200);
        builder.Property(x => x.Title).HasMaxLength(150);
        builder.Property(x => x.Text).HasMaxLength(500);

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}