using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GagerApp.WebAPI.Models;

namespace GagerApp.WebAPI.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RefreshToken> RefreshTokens
        {
            get; set;
        }

        public virtual DbSet<CatalogAdress> CatalogAdress { get; set; }
        public virtual DbSet<CatalogBrigada> CatalogBrigada { get; set; }
        public virtual DbSet<CatalogCartClient> CatalogCartClient { get; set; }
        public virtual DbSet<CatalogMatUsl> CatalogMatUsl { get; set; }
        public virtual DbSet<CatalogRoom> CatalogRoom { get; set; }
        public virtual DbSet<CatalogTelNumber> CatalogTelNumber { get; set; }
        public virtual DbSet<CatalogVidConstruct> CatalogVidConstruct { get; set; }
        public virtual DbSet<CountProducts> CountProducts { get; set; }
        public virtual DbSet<CounterpartyDirectory> CounterpartyDirectory { get; set; }
        public virtual DbSet<CustomerDirectory> CustomerDirectory { get; set; }
        public virtual DbSet<DirectoryLegalEntities> DirectoryLegalEntities { get; set; }
        public virtual DbSet<EMailCatalog> EMailCatalog { get; set; }
        public virtual DbSet<EmployeeSalaryHandbook> EmployeeSalaryHandbook { get; set; }
        public virtual DbSet<GuideRol> GuideRol { get; set; }
        public virtual DbSet<GuideStatusZamer> GuideStatusZamer { get; set; }
        public virtual DbSet<HiringWork> HiringWork { get; set; }
        public virtual DbSet<InstallationContracts> InstallationContracts { get; set; }
        public virtual DbSet<JobPositions> JobPositions { get; set; }
        public virtual DbSet<MovementGoods> MovementGoods { get; set; }
        public virtual DbSet<PaymentSchedule> PaymentSchedule { get; set; }
        public virtual DbSet<PieceworkPayment> PieceworkPayment { get; set; }
        public virtual DbSet<PositionSmeta> PositionSmeta { get; set; }
        public virtual DbSet<PriceMatUsl> PriceMatUsl { get; set; }
        public virtual DbSet<PriceVidConstruct> PriceVidConstruct { get; set; }
        public virtual DbSet<ProfileWorker> ProfileWorker { get; set; }
        public virtual DbSet<ScheduleVacation> ScheduleVacation { get; set; }
        public virtual DbSet<SettlementsCounterparties> SettlementsCounterparties { get; set; }
        public virtual DbSet<Timesheet> Timesheet { get; set; }
        public virtual DbSet<TipeWorks> TipeWorks { get; set; }
        public virtual DbSet<TypeMatUsl> TypeMatUsl { get; set; }
        public virtual DbSet<Units> Units { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        public virtual DbSet<WorkCodes> WorkCodes { get; set; }
        public virtual DbSet<ZayavkaMontag> ZayavkaMontag { get; set; }
        public virtual DbSet<ZayavkaZamer> ZayavkaZamer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("workstation id=GagerApp.mssql.somee.com;packet size=4096;user id=kras_v_SQLLogin_1;pwd=g9bs84gwte;data source=GagerApp.mssql.somee.com;persist security info=False;initial catalog=GagerApp");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogAdress>(entity =>
            {
                entity.HasKey(e => new { e.IdAdress, e.IdPartner })
                    .HasName("ID_adress");

                entity.Property(e => e.IdAdress).ValueGeneratedOnAdd();

                entity.Property(e => e.Burg).IsUnicode(false);

                entity.Property(e => e.NumberDom).IsUnicode(false);

                entity.Property(e => e.Ulica).IsUnicode(false);

                entity.HasOne(d => d.IdPartnerNavigation)
                    .WithMany(p => p.CatalogAdress)
                    .HasForeignKey(d => d.IdPartner)
                    .HasConstraintName("Counterparty_directory__Catalog_adress");
            });

            modelBuilder.Entity<CatalogBrigada>(entity =>
            {
                entity.HasKey(e => e.IdBrigada)
                    .HasName("ID_brigada");
            });

            modelBuilder.Entity<CatalogCartClient>(entity =>
            {
                entity.HasKey(e => e.IdCartClient)
                    .HasName("ID_cart_client");

                entity.HasIndex(e => e.IdCustomerDirectory)
                    .HasName("IX_Customer_directory__Catalog_cart_client");

                entity.HasOne(d => d.IdCustomerDirectoryNavigation)
                    .WithMany(p => p.CatalogCartClient)
                    .HasForeignKey(d => d.IdCustomerDirectory)
                    .HasConstraintName("Customer_directory__Catalog_cart_client");
            });

            modelBuilder.Entity<CatalogMatUsl>(entity =>
            {
                entity.HasKey(e => e.IdCatalog)
                    .HasName("ID_catalog");

                entity.HasIndex(e => e.IdTypeMatUsl)
                    .HasName("IX_Type_mat_usl__Catalog_mat_usl");

                entity.HasIndex(e => e.IdUnits)
                    .HasName("IX_Catalog_mat_usl__Units");

                entity.Property(e => e.NameMatUsl).IsUnicode(false);

                entity.HasOne(d => d.IdTypeMatUslNavigation)
                    .WithMany(p => p.CatalogMatUsl)
                    .HasForeignKey(d => d.IdTypeMatUsl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Type_mat_usl__Catalog_mat_usl");

                entity.HasOne(d => d.IdUnitsNavigation)
                    .WithMany(p => p.CatalogMatUsl)
                    .HasForeignKey(d => d.IdUnits)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Catalog_mat_usl__Units");
            });

            modelBuilder.Entity<CatalogRoom>(entity =>
            {
                entity.HasKey(e => new { e.IdRoom, e.IdAdress, e.IdPartner })
                    .HasName("ID_room");

                entity.HasIndex(e => e.IdConstruct)
                    .HasName("IX_Guide_room__Guide_vid_construct");

                entity.HasIndex(e => e.IdMontag)
                    .HasName("IX_Zayavka_montag__Catalog_room");

                entity.HasIndex(e => e.IdZayavka)
                    .HasName("IX_Zayavka_zamer__Catalog_room");

                entity.Property(e => e.IdRoom).ValueGeneratedOnAdd();

                entity.Property(e => e.NameRoom).IsUnicode(false);

                entity.HasOne(d => d.IdConstructNavigation)
                    .WithMany(p => p.CatalogRoom)
                    .HasForeignKey(d => d.IdConstruct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Guide_room__Guide_vid_construct");

                entity.HasOne(d => d.IdMontagNavigation)
                    .WithMany(p => p.CatalogRoom)
                    .HasForeignKey(d => d.IdMontag)
                    .HasConstraintName("Zayavka_montag__Catalog_room");

                entity.HasOne(d => d.IdZayavkaNavigation)
                    .WithMany(p => p.CatalogRoom)
                    .HasForeignKey(d => d.IdZayavka)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zayavka_zamer__Catalog_room");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.CatalogRoom)
                    .HasForeignKey(d => new { d.IdAdress, d.IdPartner })
                    .HasConstraintName("Guide_adress__Guide_room");
            });

            modelBuilder.Entity<CatalogTelNumber>(entity =>
            {
                entity.HasKey(e => new { e.IdNumberTel, e.IdPartner })
                    .HasName("ID_number_tel");

                entity.Property(e => e.IdNumberTel).ValueGeneratedOnAdd();

                entity.Property(e => e.NumberTel).IsUnicode(false);

                entity.HasOne(d => d.IdPartnerNavigation)
                    .WithMany(p => p.CatalogTelNumber)
                    .HasForeignKey(d => d.IdPartner)
                    .HasConstraintName("Counterparty_directory__Catalog_tel");
            });

            modelBuilder.Entity<CatalogVidConstruct>(entity =>
            {
                entity.HasKey(e => e.IdConstruct)
                    .HasName("ID_vid_construct");

                entity.Property(e => e.NameConstruct).IsUnicode(false);
            });

            modelBuilder.Entity<CountProducts>(entity =>
            {
                entity.HasKey(e => new { e.IdCountProducts, e.IdCatalog, e.IdMovementDoc })
                    .HasName("ID_count_products");

                entity.Property(e => e.IdCountProducts).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdCatalogNavigation)
                    .WithMany(p => p.CountProducts)
                    .HasForeignKey(d => d.IdCatalog)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Catalog_mat_usl__Count_products");

                entity.HasOne(d => d.IdMovementDocNavigation)
                    .WithMany(p => p.CountProducts)
                    .HasForeignKey(d => d.IdMovementDoc)
                    .HasConstraintName("Count_products__Movement_goods");
            });

            modelBuilder.Entity<CounterpartyDirectory>(entity =>
            {
                entity.HasKey(e => e.IdPartner)
                    .HasName("ID_partner");

                entity.HasIndex(e => e.IdCustomerDirectory)
                    .HasName("IX_Customer_directory__Counterparty");

                entity.HasOne(d => d.IdCustomerDirectoryNavigation)
                    .WithMany(p => p.CounterpartyDirectory)
                    .HasForeignKey(d => d.IdCustomerDirectory)
                    .HasConstraintName("Customer_directory__Counterparty");
            });

            modelBuilder.Entity<CustomerDirectory>(entity =>
            {
                entity.HasKey(e => e.IdCustomerDirectory)
                    .HasName("ID_customer_directory");

                entity.HasIndex(e => e.IdDirectoryLegalEntities)
                    .HasName("IX_Directory_ legal_entities__Customer");

                entity.Property(e => e.NameClient).IsUnicode(false);

                entity.Property(e => e.PaternumClient).IsUnicode(false);

                entity.Property(e => e.SurnameClient).IsUnicode(false);

                entity.HasOne(d => d.IdDirectoryLegalEntitiesNavigation)
                    .WithMany(p => p.CustomerDirectory)
                    .HasForeignKey(d => d.IdDirectoryLegalEntities)
                    .HasConstraintName("Directory_ legal_entities__Customer");
            });

            modelBuilder.Entity<DirectoryLegalEntities>(entity =>
            {
                entity.HasKey(e => e.IdDirectoryLegalEntities)
                    .HasName("ID_Directory_legal_entities");

                entity.HasIndex(e => e.IdPartner)
                    .HasName("IX_Counterparty_directory__Directory");

                entity.Property(e => e.FullNameCompany).IsUnicode(false);

                entity.Property(e => e.NameCompany).IsUnicode(false);

                entity.HasOne(d => d.IdPartnerNavigation)
                    .WithMany(p => p.DirectoryLegalEntities)
                    .HasForeignKey(d => d.IdPartner)
                    .HasConstraintName("Counterparty_directory__Directory");
            });

            modelBuilder.Entity<EMailCatalog>(entity =>
            {
                entity.HasKey(e => new { e.IdEMailCatalog, e.IdPartner })
                    .HasName("ID_e-mail_catalog");

                entity.Property(e => e.IdEMailCatalog).ValueGeneratedOnAdd();

                entity.Property(e => e.EMail).IsUnicode(false);

                entity.HasOne(d => d.IdPartnerNavigation)
                    .WithMany(p => p.EMailCatalog)
                    .HasForeignKey(d => d.IdPartner)
                    .HasConstraintName("Counterparty_directory__E-mail_catalog");
            });

            modelBuilder.Entity<EmployeeSalaryHandbook>(entity =>
            {
                entity.HasKey(e => new { e.IdEmployeeSalaryHandbook, e.IdProfileWorker })
                    .HasName("ID_employee_salary_handbook");

                entity.Property(e => e.IdEmployeeSalaryHandbook).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdProfileWorkerNavigation)
                    .WithMany(p => p.EmployeeSalaryHandbook)
                    .HasForeignKey(d => d.IdProfileWorker)
                    .HasConstraintName("Profile_worker__Employee_salary");
            });

            modelBuilder.Entity<GuideRol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("ID_rol");

                entity.Property(e => e.NameRol).IsUnicode(false);
            });

            modelBuilder.Entity<GuideStatusZamer>(entity =>
            {
                entity.HasKey(e => e.IdStatusZamer)
                    .HasName("ID_status_zamer");

                entity.Property(e => e.NameStatusZamer).IsUnicode(false);
            });

            modelBuilder.Entity<HiringWork>(entity =>
            {
                entity.HasKey(e => new { e.IdRecruitment, e.IdProfileWorker })
                    .HasName("ID_recruitment");

                entity.HasIndex(e => e.IdJobPosition)
                    .HasName("IX_Hiring_work__Job_positions");

                entity.Property(e => e.IdRecruitment).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdJobPositionNavigation)
                    .WithMany(p => p.HiringWork)
                    .HasForeignKey(d => d.IdJobPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Hiring_work__Job_positions");

                entity.HasOne(d => d.IdProfileWorkerNavigation)
                    .WithMany(p => p.HiringWork)
                    .HasForeignKey(d => d.IdProfileWorker)
                    .HasConstraintName("Profile_worker__Hiring_work");
            });

            modelBuilder.Entity<InstallationContracts>(entity =>
            {
                entity.HasKey(e => e.IdInstallationContracts)
                    .HasName("ID_installation_contracts");
            });

            modelBuilder.Entity<JobPositions>(entity =>
            {
                entity.HasKey(e => e.IdJobPosition)
                    .HasName("ID_job_position");
            });

            modelBuilder.Entity<MovementGoods>(entity =>
            {
                entity.HasKey(e => e.IdMovementDoc)
                    .HasName("ID_movement_doc");

                entity.HasIndex(e => e.IdPartner)
                    .HasName("IX_Counterparty_directory__Movement_goods");

                entity.HasOne(d => d.IdPartnerNavigation)
                    .WithMany(p => p.MovementGoods)
                    .HasForeignKey(d => d.IdPartner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Counterparty_directory__Movement_goods");
            });

            modelBuilder.Entity<PaymentSchedule>(entity =>
            {
                entity.HasKey(e => new { e.IdPaymentSchedule, e.IdInstallationContracts })
                    .HasName("ID_payment_schedule");

                entity.Property(e => e.IdPaymentSchedule).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdInstallationContractsNavigation)
                    .WithMany(p => p.PaymentSchedule)
                    .HasForeignKey(d => d.IdInstallationContracts)
                    .HasConstraintName("Payment_schedule__Installation_contracts");
            });

            modelBuilder.Entity<PieceworkPayment>(entity =>
            {
                entity.HasKey(e => new { e.IdPieceworkPayment, e.IdProfileWorker })
                    .HasName("ID_piecework_payment");

                entity.Property(e => e.IdPieceworkPayment).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdProfileWorkerNavigation)
                    .WithMany(p => p.PieceworkPayment)
                    .HasForeignKey(d => d.IdProfileWorker)
                    .HasConstraintName("Profile_worker__Piecework_payment");
            });

            modelBuilder.Entity<PositionSmeta>(entity =>
            {
                entity.HasKey(e => new { e.IdPositionSmeta, e.IdRoom, e.IdAdress, e.IdCatalog, e.IdPartner })
                    .HasName("ID_position_smeta");

                entity.Property(e => e.IdPositionSmeta).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdCatalogNavigation)
                    .WithMany(p => p.PositionSmeta)
                    .HasForeignKey(d => d.IdCatalog)
                    .HasConstraintName("Position_smeta__Catalog_mat_usl");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.PositionSmeta)
                    .HasForeignKey(d => new { d.IdRoom, d.IdAdress, d.IdPartner })
                    .HasConstraintName("Guide_room__Position_smeta");
            });

            modelBuilder.Entity<PriceMatUsl>(entity =>
            {
                entity.HasKey(e => new { e.IdPriceMatUsl, e.IdCatalog })
                    .HasName("ID_price_mat_usl");

                entity.Property(e => e.IdPriceMatUsl).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdCatalogNavigation)
                    .WithMany(p => p.PriceMatUsl)
                    .HasForeignKey(d => d.IdCatalog)
                    .HasConstraintName("Catalog_mat_usl__Price_mat_usl");
            });

            modelBuilder.Entity<PriceVidConstruct>(entity =>
            {
                entity.HasKey(e => new { e.IdPriceVidConstruct, e.IdConstruct })
                    .HasName("ID_price_vid_construct");

                entity.Property(e => e.IdPriceVidConstruct).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdConstructNavigation)
                    .WithMany(p => p.PriceVidConstruct)
                    .HasForeignKey(d => d.IdConstruct)
                    .HasConstraintName("Guide_vid_construct__Price_vid_construct");
            });

            modelBuilder.Entity<ProfileWorker>(entity =>
            {
                entity.HasKey(e => e.IdProfileWorker)
                    .HasName("ID_profile_worker");

                entity.HasIndex(e => e.IdBrigada)
                    .HasName("IX_Catalog_brigada__Profile_worker");

                entity.HasIndex(e => e.IdTipeWorks)
                    .HasName("IX_Tipe_works__Profile_worker");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Paternum).IsUnicode(false);

                entity.Property(e => e.Surname).IsUnicode(false);

                entity.HasOne(d => d.IdBrigadaNavigation)
                    .WithMany(p => p.ProfileWorker)
                    .HasForeignKey(d => d.IdBrigada)
                    .HasConstraintName("Catalog_brigada__Profile_worker");

                entity.HasOne(d => d.IdTipeWorksNavigation)
                    .WithMany(p => p.ProfileWorker)
                    .HasForeignKey(d => d.IdTipeWorks)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Tipe_works__Profile_worker");
            });

            modelBuilder.Entity<ScheduleVacation>(entity =>
            {
                entity.HasKey(e => new { e.IdScheduleVacation, e.IdProfileWorker })
                    .HasName("ID_schedule_vacation");

                entity.Property(e => e.IdScheduleVacation).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdProfileWorkerNavigation)
                    .WithMany(p => p.ScheduleVacation)
                    .HasForeignKey(d => d.IdProfileWorker)
                    .HasConstraintName("Profile_worker__Schedule_vacation");
            });

            modelBuilder.Entity<SettlementsCounterparties>(entity =>
            {
                entity.HasKey(e => new { e.SettlementsCounterparties1, e.IdPartner })
                    .HasName("ID_Settlements_counterparties");

                entity.HasIndex(e => e.IdInstallationContracts)
                    .HasName("IX_Settlements_counterparties_Installation");

                entity.Property(e => e.SettlementsCounterparties1).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdInstallationContractsNavigation)
                    .WithMany(p => p.SettlementsCounterparties)
                    .HasForeignKey(d => d.IdInstallationContracts)
                    .HasConstraintName("Settlements_counterparties_Installation");

                entity.HasOne(d => d.IdPartnerNavigation)
                    .WithMany(p => p.SettlementsCounterparties)
                    .HasForeignKey(d => d.IdPartner)
                    .HasConstraintName("Counterparty_directory__Settlements");
            });

            modelBuilder.Entity<Timesheet>(entity =>
            {
                entity.HasKey(e => new { e.IdTimesheet, e.IdProfileWorker })
                    .HasName("ID_timesheet");

                entity.HasIndex(e => e.IdWorkCode)
                    .HasName("IX_Work_codes__Timesheet");

                entity.Property(e => e.IdTimesheet).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdProfileWorkerNavigation)
                    .WithMany(p => p.Timesheet)
                    .HasForeignKey(d => d.IdProfileWorker)
                    .HasConstraintName("Profile_worker__Timesheet");

                entity.HasOne(d => d.IdWorkCodeNavigation)
                    .WithMany(p => p.Timesheet)
                    .HasForeignKey(d => d.IdWorkCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Work_codes__Timesheet");
            });

            modelBuilder.Entity<TipeWorks>(entity =>
            {
                entity.HasKey(e => e.IdTipeWorks)
                    .HasName("ID_tipe_works");

                entity.Property(e => e.NameTipeWork).IsUnicode(false);
            });

            modelBuilder.Entity<TypeMatUsl>(entity =>
            {
                entity.HasKey(e => e.IdTypeMatUsl)
                    .HasName("ID_type_mat_usl");

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Units>(entity =>
            {
                entity.HasKey(e => e.IdUnits)
                    .HasName("ID_units");

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => new { e.IdUser, e.IdProfileWorker })
                    .HasName("ID");

                entity.HasIndex(e => e.IdRol)
                    .HasName("IX_Guide_rol__User_profile");

                entity.Property(e => e.IdUser).ValueGeneratedOnAdd();

                entity.Property(e => e.Login).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.HasOne(d => d.IdProfileWorkerNavigation)
                    .WithMany(p => p.UserProfile)
                    .HasForeignKey(d => d.IdProfileWorker)
                    .HasConstraintName("User_profile__Profile_worker");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.UserProfile)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Guide_rol__User_profile");
            });

            modelBuilder.Entity<WorkCodes>(entity =>
            {
                entity.HasKey(e => e.IdWorkCode)
                    .HasName("ID_work_code");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Signature).IsUnicode(false);
            });

            modelBuilder.Entity<ZayavkaMontag>(entity =>
            {
                entity.HasKey(e => e.IdMontag)
                    .HasName("ID_montag");

                entity.HasIndex(e => e.IdBrigada)
                    .HasName("IX_Montag_to_Guide_brigada");

                entity.HasIndex(e => e.IdInstallationContracts)
                    .HasName("IX_Installation_contracts__Zayavka_montag");

                entity.HasIndex(e => new { e.IdAdress, e.IdPartner })
                    .HasName("IX_Guide_adress__Zayavka_montag");

                entity.HasOne(d => d.IdBrigadaNavigation)
                    .WithMany(p => p.ZayavkaMontag)
                    .HasForeignKey(d => d.IdBrigada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Montag_to_Guide_brigada");

                entity.HasOne(d => d.IdInstallationContractsNavigation)
                    .WithMany(p => p.ZayavkaMontag)
                    .HasForeignKey(d => d.IdInstallationContracts)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Installation_contracts__Zayavka_montag");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.ZayavkaMontag)
                    .HasForeignKey(d => new { d.IdAdress, d.IdPartner })
                    .HasConstraintName("Guide_adress__Zayavka_montag");
            });

            modelBuilder.Entity<ZayavkaZamer>(entity =>
            {
                entity.HasKey(e => e.IdZayavka)
                    .HasName("ID_zayavka");

                entity.HasIndex(e => e.IdPartner)
                    .HasName("IX_Counterparty_directory__Zayavka_zamer");

                entity.HasIndex(e => e.IdProfileWorker)
                    .HasName("IX_Profile_worker__Zayavka_zamer");

                entity.HasIndex(e => e.IdStatusZamer)
                    .HasName("IX_Zayavka_to_Guide_status_zamer");

                entity.HasIndex(e => new { e.IdAdress, e.IdPartner })
                    .HasName("IX_Zayavka_to_Guide_adress");

                entity.Property(e => e.Notice).IsUnicode(false);

                entity.HasOne(d => d.IdPartnerNavigation)
                    .WithMany(p => p.ZayavkaZamer)
                    .HasForeignKey(d => d.IdPartner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Counterparty_directory__Zayavka_zamer");

                entity.HasOne(d => d.IdProfileWorkerNavigation)
                    .WithMany(p => p.ZayavkaZamer)
                    .HasForeignKey(d => d.IdProfileWorker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Profile_worker__Zayavka_zamer");

                entity.HasOne(d => d.IdStatusZamerNavigation)
                    .WithMany(p => p.ZayavkaZamer)
                    .HasForeignKey(d => d.IdStatusZamer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zayavka_to_Guide_status_zamer");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.ZayavkaZamer)
                    .HasForeignKey(d => new { d.IdAdress, d.IdPartner })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zayavka_to_Guide_adress");
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasIndex(e => e.UserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
