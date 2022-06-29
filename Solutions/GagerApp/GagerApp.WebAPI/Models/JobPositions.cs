using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Job_positions")]
    public partial class JobPositions
    {
        public JobPositions()
        {
            HiringWork = new HashSet<HiringWork>();
        }

        [Key]
        [Column("ID_job_position")]
        public long IdJobPosition { get; set; }
        [Column("Job_title")]
        public long JobTitle { get; set; }

        [InverseProperty("IdJobPositionNavigation")]
        public virtual ICollection<HiringWork> HiringWork { get; set; }
    }
}
