using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Movement_goods")]
    public partial class MovementGoods
    {
        public MovementGoods()
        {
            CountProducts = new HashSet<CountProducts>();
        }

        [Key]
        [Column("ID_movement_doc")]
        public long IdMovementDoc { get; set; }
        [Column("Date_doc", TypeName = "datetime")]
        public DateTime DateDoc { get; set; }
        [Column("number_doc")]
        public int NumberDoc { get; set; }
        [Column("Tipe_doc")]
        public bool TipeDoc { get; set; }
        [Column("ID_partner")]
        public long IdPartner { get; set; }

        [ForeignKey(nameof(IdPartner))]
        [InverseProperty(nameof(CounterpartyDirectory.MovementGoods))]
        public virtual CounterpartyDirectory IdPartnerNavigation { get; set; }
        [InverseProperty("IdMovementDocNavigation")]
        public virtual ICollection<CountProducts> CountProducts { get; set; }
    }
}
