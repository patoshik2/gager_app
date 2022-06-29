using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Piecework_payment")]
    public partial class PieceworkPayment
    {
        [Key]
        [Column("ID_piecework_payment")]
        public long IdPieceworkPayment { get; set; }
        [Column("Sum_piecework")]
        public double SumPiecework { get; set; }
        [Column("Start_piecework", TypeName = "datetime")]
        public DateTime StartPiecework { get; set; }
        [Column("End_piecework", TypeName = "datetime")]
        public DateTime EndPiecework { get; set; }
        [Key]
        [Column("ID_profile_worker")]
        public long IdProfileWorker { get; set; }

        [ForeignKey(nameof(IdProfileWorker))]
        [InverseProperty(nameof(ProfileWorker.PieceworkPayment))]
        public virtual ProfileWorker IdProfileWorkerNavigation { get; set; }
    }
}
