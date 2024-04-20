using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkShare.Infrastructure.Data.Entities;

namespace WorkShare.Infrastructure.Data.EntitiesConfiguration
{
    internal class WorkTypeConfiguration : IEntityTypeConfiguration<WorkTypeEntity>
    {
        public void Configure(EntityTypeBuilder<WorkTypeEntity> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name).IsRequired();

            builder.HasMany(w => w.WorkEntities)
                   .WithOne(w => w.WorkTypeEntity);
        }
    }
}
