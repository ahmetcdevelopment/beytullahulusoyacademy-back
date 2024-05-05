using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TrainingConfiguration : IEntityTypeConfiguration<Training>
{
    public void Configure(EntityTypeBuilder<Training> builder)
    {
        builder.ToTable("Trainings").HasKey(t => t.Id);

        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
        builder.Property(t => t.RoomId).HasColumnName("RoomId");
        builder.Property(t => t.GroupId).HasColumnName("GroupId");
        builder.Property(t => t.StartDate).HasColumnName("StartDate");
        builder.Property(t => t.EndDate).HasColumnName("EndDate");
        builder.Property(t => t.Note).HasColumnName("Note");
        builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate");

        builder.Property(x => x.Note).HasMaxLength(500);
        builder.HasOne(x => x.TrainingRoom);
        builder.HasMany(x => x.Attendances);
        builder.HasOne(x => x.Group);

        builder.HasQueryFilter(t => !t.DeletedDate.HasValue);
    }
}