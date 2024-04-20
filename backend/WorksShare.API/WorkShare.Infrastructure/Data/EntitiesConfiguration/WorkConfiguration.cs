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
            builder.Property(w => w.Description);
            builder.Property(w => w.Course).IsRequired();
            builder.Property(w => w.CreatedAt).IsRequired();

            builder.HasOne(w => w.UserEntity)
                   .WithMany(u => u.WorkEntities);

            builder.HasOne(w => w.SubjectEntity)
                   .WithMany(s => s.WorkEntities);

            builder.HasOne(w => w.TaskSource)
                   .WithMany(t => t.WorkEntities);

            builder.HasOne(w => w.WorkTypeEntity)
                   .WithMany(w => w.WorkEntities);
        }
    }
}
