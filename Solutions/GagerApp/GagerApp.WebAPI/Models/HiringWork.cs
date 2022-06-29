using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Hiring_work")]
    public partial class HiringWork
    {
        [Key]
        [Column("ID_recruitment")]
        public long IdRecruitment { get; set; }
        [Column("Date_recruitment", TypeName = "datetime")]
        public DateTime DateRecruitment { get; set; }
        [Column("Date_dismissal", TypeName = "datetime")]
        public DateTime? DateDismissal { get; set; }
        [Key]
        [Column("ID_profile_worker")]
        public long IdProfileWorker { get; set; }
        [Column("ID_job_position")]
        public long IdJobPosition { get; set; }

        [ForeignKey(nameof(IdJobPosition))]
        [InverseProperty(nameof(JobPositions.HiringWork))]
        public virtual JobPositions IdJobPositionNavigation { get; set; }
        [ForeignKey(nameof(IdProfileWorker))]
        [InverseProperty(nameof(ProfileWorker.HiringWork))]
        public virtual ProfileWorker IdProfileWorkerNavigation { get; set; }
    }
}
