using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Hims_WebAPI.ViewModel;
using Hims_WebAPI.ViewModel;

#nullable disable

namespace Hims_WebAPI.StoreProcedures
{
    public partial class StoreProceduresContext : DbContext
    {
        public StoreProceduresContext()
        {
        }

        public StoreProceduresContext(DbContextOptions<StoreProceduresContext> options)
            : base(options)
        {
        }

        

        public virtual DbSet<SearchRegistrationPatientsVo> SP_SearchRegisterPatientsbytoday { get; set; }
        public virtual DbSet<SearchRegistrationPatientsVo> SP_SearchRegisteredPatients { get; set; }
        public virtual DbSet<PatientDetailsSPVo> GetPatientDetails { get; set; }
        public virtual DbSet<SearchPatientVo> SP_SearchPatients { get; set; }
        public virtual DbSet<PatientVo> GetPatientDetailsByID { get; set; }
        public virtual DbSet<SearchPatientVo> SP_SearchPatientsbytoday { get; set; }

        public virtual DbSet<RegistrationPaymentsVo> SP_GetPatientRegistrationDetails { get; set; }
        public virtual DbSet<SearchPatientsbyNurseVo> SP_SearchPatientsbyNurse { get; set; }
        public virtual DbSet<RegistrationConsulatationPaymentVo> SP_GetPatientRegistrationandConsulatationDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("Server=10.10.20.25;Database=bhishak_app_db; User=root;Password=root@123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            modelBuilder.Entity<PatientDetailsSPVo>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<PatientVo>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<SearchPatientVo>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<RegistrationPaymentsVo>(entity =>
            {
                entity.HasNoKey();
            });
            OnModelCreatingPartial(modelBuilder);
            modelBuilder.Entity<RegistrationConsulatationPaymentVo>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<SearchPatientsbyNurseVo>(entity =>
            {
                entity.HasNoKey();
            });
            OnModelCreatingPartial(modelBuilder);
            modelBuilder.Entity<SearchRegistrationPatientsVo>(entity =>
            {
                entity.HasNoKey();
            });
            OnModelCreatingPartial(modelBuilder);
            
        }
      

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
