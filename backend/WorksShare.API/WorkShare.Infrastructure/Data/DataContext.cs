using Microsoft.EntityFrameworkCore;
using WorkShare.Infrastructure.Data.Entities;
using WorkShare.Infrastructure.Data.EntitiesConfiguration;

namespace WorkShare.Infrastructure.Data
{
    public class DataContext: DbContext
    {
        internal DbSet<UserEntity> Users { get; set; }
        internal DbSet<WorkEntity> Works { get; set; }
        internal DbSet<FileEnity> Files { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FileConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new WorkConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
