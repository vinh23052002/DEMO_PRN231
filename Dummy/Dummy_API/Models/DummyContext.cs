﻿using Microsoft.EntityFrameworkCore;

namespace Dummy_API.Models
{
    public partial class DummyContext : DbContext
    {
        public DummyContext()
        {
        }

        public DummyContext(DbContextOptions<DummyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DummyDetail> DummyDetails { get; set; } = null!;
        public virtual DbSet<DummyMaster> DummyMasters { get; set; } = null!;

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
            modelBuilder.Entity<DummyDetail>(entity =>
            {
                entity.HasKey(e => e.DetailId);

                entity.ToTable("DummyDetail");

                entity.Property(e => e.DetailId).HasColumnName("detail_id");

                entity.Property(e => e.DetailName)
                    .HasMaxLength(50)
                    .HasColumnName("detail_name");

                entity.Property(e => e.MasterId).HasColumnName("master_id");

                entity.HasOne(d => d.Master)
                    .WithMany(p => p.DummyDetails)
                    .HasForeignKey(d => d.MasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DummyDetail_DummyMaster");
            });

            modelBuilder.Entity<DummyMaster>(entity =>
            {
                entity.HasKey(e => e.MasterId);

                entity.ToTable("DummyMaster");

                entity.Property(e => e.MasterId).HasColumnName("master_id");

                entity.Property(e => e.MasterName)
                    .HasMaxLength(50)
                    .HasColumnName("master_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
