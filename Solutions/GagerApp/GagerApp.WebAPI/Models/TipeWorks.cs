using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Tipe_works")]
    public partial class TipeWorks
    {
        public TipeWorks()
        {
            ProfileWorker = new HashSet<ProfileWorker>();
        }

        [Key]
        [Column("ID_tipe_works")]
        public long IdTipeWorks { get; set; }
        [Required]
        [Column("Name_tipe_work")]
        [StringLength(30)]
        public string NameTipeWork { get; set; }

        [InverseProperty("IdTipeWorksNavigation")]
        public virtual ICollection<ProfileWorker> ProfileWorker { get; set; }
    }
}
