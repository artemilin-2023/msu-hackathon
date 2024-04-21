using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkShare.Infrastructure.Data.Entities;

namespace WorkShare.Infrastructure.Data.EntitiesConfiguration
{
    internal class FileConfiguration : IEntityTypeConfiguration<FileEnity>
    {
        public void Configure(EntityTypeBuilder<FileEnity> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Path).IsRequired();

            builder.HasOne(f => f.WorkEntity)
                   .WithMany(f => f.Files);
        }
    }
}
