using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkShare.Infrastructure.Data.Entities;

namespace WorkShare.Infrastructure.Data.EntitiesConfiguration
{
    internal class SubjectConfiguration : IEntityTypeConfiguration<SubjectEntity>
    {
        public void Configure(EntityTypeBuilder<SubjectEntity> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name).IsRequired();

            builder.HasMany(s => s.WorkEntities)
                   .WithOne(w => w.SubjectEntity);
        }
    }
}
