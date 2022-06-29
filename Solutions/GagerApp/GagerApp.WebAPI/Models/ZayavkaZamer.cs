using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Zayavka_zamer")]
    public partial class ZayavkaZamer
    {
        public ZayavkaZamer()
        {
            CatalogRoom = new HashSet<CatalogRoom>();
        }

        [Key]
        [Column("ID_zayavka")]
        public long IdZayavka { get; set; }
        [Column("Date_zamer", TypeName = "date")]
        public DateTime DateZamer { get; set; }
        [Column("Time_start_zamer")]
        public TimeSpan TimeStartZamer { get; set; }
        [Column("Time_stop_zamer")]
        public TimeSpan TimeStopZamer { get; set; }
        [StringLength(150)]
        public string Notice { get; set; }
        [Column("ID_status_zamer")]
        public long IdStatusZamer { get; set; }
        [Column("ID_adress")]
        public long IdAdress { get; set; }
        [Column("ID_partner")]
        public long IdPartner { get; set; }
        [Column("ID_profile_worker")]
        public long IdProfileWorker { get; set; }

        [ForeignKey("IdAdress,IdPartner")]
        [InverseProperty(nameof(CatalogAdress.ZayavkaZamer))]
        public virtual CatalogAdress Id { get; set; }
        [ForeignKey(nameof(IdPartner))]
        [InverseProperty(nameof(CounterpartyDirectory.ZayavkaZamer))]
        public virtual CounterpartyDirectory IdPartnerNavigation { get; set; }
        [ForeignKey(nameof(IdProfileWorker))]
        [InverseProperty(nameof(ProfileWorker.ZayavkaZamer))]
        public virtual ProfileWorker IdProfileWorkerNavigation { get; set; }
        [ForeignKey(nameof(IdStatusZamer))]
        [InverseProperty(nameof(GuideStatusZamer.ZayavkaZamer))]
        public virtual GuideStatusZamer IdStatusZamerNavigation { get; set; }
        [InverseProperty("IdZayavkaNavigation")]
        public virtual ICollection<CatalogRoom> CatalogRoom { get; set; }
    }
}
