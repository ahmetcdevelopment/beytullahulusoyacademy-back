using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TrainingRoomConfiguration : IEntityTypeConfiguration<TrainingRoom>
{
    public void Configure(EntityTypeBuilder<TrainingRoom> builder)
    {
        builder.ToTable("TrainingRooms").HasKey(tr => tr.Id);

        builder.Property(tr => tr.Id).HasColumnName("Id").IsRequired();
        builder.Property(tr => tr.Name).HasColumnName("Name");
        builder.Property(tr => tr.Link).HasColumnName("Link");
        builder.Property(tr => tr.Enlem).HasColumnName("Enlem");
        builder.Property(tr => tr.Boylam).HasColumnName("Boylam");
        builder.Property(tr => tr.Address).HasColumnName("Address");
        builder.Property(tr => tr.Picture).HasColumnName("Picture");
        builder.Property(tr => tr.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(tr => tr.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(tr => tr.DeletedDate).HasColumnName("DeletedDate");

        builder.Property(x => x.Name).HasMaxLength(100);
        builder.Property(x => x.Link).HasMaxLength(150);
        builder.Property(x => x.Address).HasMaxLength(200);
        builder.Property(x => x.Picture).HasMaxLength(100);
        builder.HasMany(x => x.Trainings);
        builder.HasQueryFilter(tr => !tr.DeletedDate.HasValue);
    }
}