using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("E-mail_catalog")]
    public partial class EMailCatalog
    {
        [Key]
        [Column("ID_e-mail_catalog")]
        public long IdEMailCatalog { get; set; }
        [Required]
        [Column("E_mail")]
        [StringLength(30)]
        public string EMail { get; set; }
        [Key]
        [Column("ID_partner")]
        public long IdPartner { get; set; }

        [ForeignKey(nameof(IdPartner))]
        [InverseProperty(nameof(CounterpartyDirectory.EMailCatalog))]
        public virtual CounterpartyDirectory IdPartnerNavigation { get; set; }
    }
}
