using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataLayer.HealthCare.DataModels
{
    public partial class ComfortHealthContext : DbContext
    {
        public ComfortHealthContext()
        {
        }

        public ComfortHealthContext(DbContextOptions<ComfortHealthContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PatientHistoryDetail> PatientHistoryDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("Doctor");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Contact).HasMaxLength(50);

                entity.Property(e => e.DoctorEmail).HasMaxLength(200);

                entity.Property(e => e.DoctorIdentity).HasMaxLength(50);

                entity.Property(e => e.DoctorName).HasMaxLength(100);

                entity.Property(e => e.Others).HasMaxLength(1000);

                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .HasColumnName("password");

                entity.Property(e => e.Specility)
                    .HasMaxLength(100)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Contact)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.Nrc)
                    .HasMaxLength(50)
                    .HasColumnName("NRC");

                entity.Property(e => e.PatientAddress).HasMaxLength(1000);

                entity.Property(e => e.PatientName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<PatientHistoryDetail>(entity =>
            {
                entity.ToTable("PatientHistoryDetail");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AdmissionDate).HasColumnType("datetime");

                entity.Property(e => e.AllergiesHistory).HasMaxLength(100);

                entity.Property(e => e.BloodGroup).HasMaxLength(50);

                entity.Property(e => e.Bmi).HasColumnName("BMI");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CurrentMedicineTaking).HasMaxLength(500);

                entity.Property(e => e.Diagnosis).HasMaxLength(500);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Gpefindings)
                    .HasMaxLength(500)
                    .HasColumnName("GPEFindings");

                entity.Property(e => e.Height).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.IllnessHistory).HasMaxLength(500);

                entity.Property(e => e.Investigation).HasMaxLength(500);

                entity.Property(e => e.MaritalStatus).HasMaxLength(50);

                entity.Property(e => e.Occupation).HasMaxLength(50);

                entity.Property(e => e.Others).HasMaxLength(100);

                entity.Property(e => e.PastMedicineTaking).HasMaxLength(500);

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.Property(e => e.Religion).HasMaxLength(50);

                entity.Property(e => e.Treatment).HasMaxLength(500);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 5)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
