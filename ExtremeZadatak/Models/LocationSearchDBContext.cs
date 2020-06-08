using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExtremeZadatak.Models
{
    public partial class LocationSearchDBContext : DbContext
    {
        public LocationSearchDBContext()
        {
        }

        public LocationSearchDBContext(DbContextOptions<LocationSearchDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LocationSearch> LocationSearch { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-857NGIQ;Database=LocationSearchDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LocationSearch>(entity =>
            {
                entity.HasKey(e => e.SearchId)
                    .HasName("PK__Location__21C53514B1AA6181");

                entity.Property(e => e.SearchId).HasColumnName("SearchID");

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.Time).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
