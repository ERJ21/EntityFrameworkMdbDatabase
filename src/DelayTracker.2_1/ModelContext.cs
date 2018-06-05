using Microsoft.EntityFrameworkCore;

namespace DelayTracker.v2_1
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options) : base(options) { }

        public DbSet<Captains> Captains { get; set; }

        public DbSet<Projects> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Projects>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                //entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                //entity.Property(e => e.ProjectDescription).IsRequired(false);
            });

            modelBuilder.Entity<Captains>(entity =>
            {
                entity.HasKey(e => e.CaptainId);
            });
        }
    }
}
