using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
{
    public void Configure(EntityTypeBuilder<Attendance> builder)
    {
        builder.ToTable("Attendances").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.TrainingId).HasColumnName("TrainingId");
        builder.Property(a => a.UserId).HasColumnName("UserId");
        builder.Property(a => a.IsThere).HasColumnName("IsThere");
        builder.Property(a => a.Description).HasColumnName("Description");
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(x => x.User);
        builder.HasOne(x => x.Training);
        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}