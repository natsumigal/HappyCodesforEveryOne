using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataLayer.AuthTenants.DataModels
{
    public partial class TenantsContext : DbContext
    {
        public TenantsContext()
        {
        }

        public TenantsContext(DbContextOptions<TenantsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DatabaseInstance> DatabaseInstances { get; set; }
        public virtual DbSet<TenantRegistry> TenantRegistries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<DatabaseInstance>(entity =>
            {
                entity.ToTable("databaseInstances");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Connection)
                    .HasMaxLength(300)
                    .HasColumnName("connection");

                entity.Property(e => e.DatabaseKey)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("database_key");

                entity.Property(e => e.DatabaseName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("database_name");

                entity.Property(e => e.Enable).HasColumnName("enable");

                entity.Property(e => e.Others).HasColumnType("text");
            });

            modelBuilder.Entity<TenantRegistry>(entity =>
            {
                entity.ToTable("tenantRegistry");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Tenant)
                    .HasMaxLength(50)
                    .HasColumnName("tenant");

                entity.Property(e => e.TenantKey)
                    .HasMaxLength(250)
                    .HasColumnName("tenantKey");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedDate");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
