using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Work_codes")]
    public partial class WorkCodes
    {
        public WorkCodes()
        {
            Timesheet = new HashSet<Timesheet>();
        }

        [Key]
        [Column("ID_work_code")]
        public long IdWorkCode { get; set; }
        [Required]
        [StringLength(3)]
        public string Signature { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [InverseProperty("IdWorkCodeNavigation")]
        public virtual ICollection<Timesheet> Timesheet { get; set; }
    }
}
