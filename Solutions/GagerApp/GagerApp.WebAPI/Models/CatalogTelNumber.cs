using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Catalog_tel_number")]
    public partial class CatalogTelNumber
    {
        [Key]
        [Column("ID_number_tel")]
        public long IdNumberTel { get; set; }
        [Required]
        [Column("Number_tel")]
        [StringLength(12)]
        public string NumberTel { get; set; }
        [Key]
        [Column("ID_partner")]
        public long IdPartner { get; set; }

        [ForeignKey(nameof(IdPartner))]
        [InverseProperty(nameof(CounterpartyDirectory.CatalogTelNumber))]
        public virtual CounterpartyDirectory IdPartnerNavigation { get; set; }
    }
}
