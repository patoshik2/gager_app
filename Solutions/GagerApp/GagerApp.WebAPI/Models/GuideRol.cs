using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Guide_rol")]
    public partial class GuideRol
    {
        public GuideRol()
        {
            UserProfile = new HashSet<UserProfile>();
        }

        [Key]
        [Column("ID_rol")]
        public long IdRol { get; set; }
        [Required]
        [Column("Name_rol")]
        [StringLength(30)]
        public string NameRol { get; set; }

        [InverseProperty("IdRolNavigation")]
        public virtual ICollection<UserProfile> UserProfile { get; set; }
    }
}
