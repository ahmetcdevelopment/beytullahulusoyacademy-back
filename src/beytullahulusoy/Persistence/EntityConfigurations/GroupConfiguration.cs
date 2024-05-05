using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("Groups").HasKey(g => g.Id);

        builder.Property(g => g.Id).HasColumnName("Id").IsRequired();
        builder.Property(g => g.UserId).HasColumnName("UserId");
        builder.Property(g => g.Name).HasColumnName("Name");
        builder.Property(g => g.Description).HasColumnName("Description");
        builder.Property(g => g.IsTrainerGroup).HasColumnName("IsTrainerGroup");
        builder.Property(g => g.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(g => g.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(g => g.DeletedDate).HasColumnName("DeletedDate");

        builder.Property(x => x.Name).HasMaxLength(150);
        builder.Property(x => x.Description).HasMaxLength(300);

        builder.HasOne(x => x.User);
        builder.HasMany(x => x.Trainings);

        builder.HasQueryFilter(g => !g.DeletedDate.HasValue);
    }
}