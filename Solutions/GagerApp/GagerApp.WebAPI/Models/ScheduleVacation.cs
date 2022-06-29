using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Schedule_vacation")]
    public partial class ScheduleVacation
    {
        [Key]
        [Column("ID_schedule_vacation")]
        public long IdScheduleVacation { get; set; }
        [Column("start_date", TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column("end_date")]
        public long EndDate { get; set; }
        [Key]
        [Column("ID_profile_worker")]
        public long IdProfileWorker { get; set; }

        [ForeignKey(nameof(IdProfileWorker))]
        [InverseProperty(nameof(ProfileWorker.ScheduleVacation))]
        public virtual ProfileWorker IdProfileWorkerNavigation { get; set; }
    }
}
