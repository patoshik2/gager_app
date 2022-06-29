using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    public partial class Timesheet
    {
        [Key]
        [Column("ID_timesheet")]
        public long IdTimesheet { get; set; }
        [Column("Date_timesheet", TypeName = "datetime")]
        public DateTime DateTimesheet { get; set; }
        public long? Hours { get; set; }
        [Key]
        [Column("ID_profile_worker")]
        public long IdProfileWorker { get; set; }
        [Column("ID_work_code")]
        public long IdWorkCode { get; set; }

        [ForeignKey(nameof(IdProfileWorker))]
        [InverseProperty(nameof(ProfileWorker.Timesheet))]
        public virtual ProfileWorker IdProfileWorkerNavigation { get; set; }
        [ForeignKey(nameof(IdWorkCode))]
        [InverseProperty(nameof(WorkCodes.Timesheet))]
        public virtual WorkCodes IdWorkCodeNavigation { get; set; }
    }
}
