using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public partial class GoDiemContext : DbContext
    {
        public GoDiemContext()
        {
        }

        public GoDiemContext(DbContextOptions<GoDiemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Question> Questions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("SqlConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Question");

                entity.Property(e => e.A).HasMaxLength(50);

                entity.Property(e => e.Answer)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.B).HasMaxLength(50);

                entity.Property(e => e.C).HasMaxLength(50);

                entity.Property(e => e.Content).HasMaxLength(500);

                entity.Property(e => e.D).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
