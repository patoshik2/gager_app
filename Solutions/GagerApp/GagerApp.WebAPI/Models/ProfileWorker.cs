using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Profile_worker")]
    public partial class ProfileWorker
    {
        public ProfileWorker()
        {
            EmployeeSalaryHandbook = new HashSet<EmployeeSalaryHandbook>();
            HiringWork = new HashSet<HiringWork>();
            PieceworkPayment = new HashSet<PieceworkPayment>();
            ScheduleVacation = new HashSet<ScheduleVacation>();
            Timesheet = new HashSet<Timesheet>();
            UserProfile = new HashSet<UserProfile>();
            ZayavkaZamer = new HashSet<ZayavkaZamer>();
        }

        [Key]
        [Column("ID_profile_worker")]
        public long IdProfileWorker { get; set; }
        [Required]
        [StringLength(30)]
        public string Surname { get; set; }
        [Required]
        [StringLength(15)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Paternum { get; set; }
        [Column("ID_tipe_works")]
        public long IdTipeWorks { get; set; }
        [Column("ID_brigada")]
        public long? IdBrigada { get; set; }

        [ForeignKey(nameof(IdBrigada))]
        [InverseProperty(nameof(CatalogBrigada.ProfileWorker))]
        public virtual CatalogBrigada IdBrigadaNavigation { get; set; }
        [ForeignKey(nameof(IdTipeWorks))]
        [InverseProperty(nameof(TipeWorks.ProfileWorker))]
        public virtual TipeWorks IdTipeWorksNavigation { get; set; }
        [InverseProperty("IdProfileWorkerNavigation")]
        public virtual ICollection<EmployeeSalaryHandbook> EmployeeSalaryHandbook { get; set; }
        [InverseProperty("IdProfileWorkerNavigation")]
        public virtual ICollection<HiringWork> HiringWork { get; set; }
        [InverseProperty("IdProfileWorkerNavigation")]
        public virtual ICollection<PieceworkPayment> PieceworkPayment { get; set; }
        [InverseProperty("IdProfileWorkerNavigation")]
        public virtual ICollection<ScheduleVacation> ScheduleVacation { get; set; }
        [InverseProperty("IdProfileWorkerNavigation")]
        public virtual ICollection<Timesheet> Timesheet { get; set; }
        [InverseProperty("IdProfileWorkerNavigation")]
        public virtual ICollection<UserProfile> UserProfile { get; set; }
        [InverseProperty("IdProfileWorkerNavigation")]
        public virtual ICollection<ZayavkaZamer> ZayavkaZamer { get; set; }
    }
}
