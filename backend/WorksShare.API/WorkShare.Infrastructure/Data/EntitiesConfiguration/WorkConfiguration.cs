using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkShare.Infrastructure.Data.Entities;

namespace WorkShare.Infrastructure.Data.EntitiesConfiguration
{
    internal class WorkConfiguration : IEntityTypeConfiguration<WorkEntity>
    {
        public void Configure(EntityTypeBuilder<WorkEntity> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Name).IsRequired();
            builder.Property(w => w.Course).IsRequired();
            builder.Property(w => w.CreatedAt).IsRequired();
            builder.Property(w => w.Subject).IsRequired();
            builder.Property(w => w.WorkType).IsRequired();
            builder.Property(w => w.UserId).IsRequired();
        }
    }
}
