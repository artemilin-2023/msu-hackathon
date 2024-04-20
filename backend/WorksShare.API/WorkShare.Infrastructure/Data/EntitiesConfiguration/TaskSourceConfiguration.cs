using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkShare.Infrastructure.Data.Entities;

namespace WorkShare.Infrastructure.Data.EntitiesConfiguration
{
    internal class TaskSourceConfiguration : IEntityTypeConfiguration<TaskSource>
    {
        public void Configure(EntityTypeBuilder<TaskSource> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name).IsRequired();

            builder.HasMany(t => t.WorkEntities)
                   .WithOne(w => w.TaskSource);
        }
    }
}
