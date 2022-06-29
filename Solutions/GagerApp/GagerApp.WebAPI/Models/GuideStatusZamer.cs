using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Guide_status_zamer")]
    public partial class GuideStatusZamer
    {
        public GuideStatusZamer()
        {
            ZayavkaZamer = new HashSet<ZayavkaZamer>();
        }

        [Key]
        [Column("ID_status_zamer")]
        public long IdStatusZamer { get; set; }
        [Required]
        [Column("Name_status_zamer")]
        [StringLength(15)]
        public string NameStatusZamer { get; set; }

        [InverseProperty("IdStatusZamerNavigation")]
        public virtual ICollection<ZayavkaZamer> ZayavkaZamer { get; set; }
    }
}
