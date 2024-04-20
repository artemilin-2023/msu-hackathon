using Microsoft.EntityFrameworkCore;
using WorkShare.Infrastructure.Data.Entities;
using WorkShare.Infrastructure.Data.EntitiesConfiguration;

namespace WorkShare.Infrastructure.Data
{
    internal class DataContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<WorkEntity> Works { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FileConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new TaskSourceConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new WorkConfiguration());
            modelBuilder.ApplyConfiguration(new WorkTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
