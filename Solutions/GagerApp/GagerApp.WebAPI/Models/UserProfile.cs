using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("User_profile")]
    public partial class UserProfile
    {
        [Key]
        [Column("ID_user")]
        public long IdUser { get; set; }
        [Required]
        [StringLength(20)]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Key]
        [Column("ID_profile_worker")]
        public long IdProfileWorker { get; set; }
        [Column("ID_rol")]
        public long IdRol { get; set; }

        [ForeignKey(nameof(IdProfileWorker))]
        [InverseProperty(nameof(ProfileWorker.UserProfile))]
        public virtual ProfileWorker IdProfileWorkerNavigation { get; set; }
        [ForeignKey(nameof(IdRol))]
        [InverseProperty(nameof(GuideRol.UserProfile))]
        public virtual GuideRol IdRolNavigation { get; set; }
    }
}
