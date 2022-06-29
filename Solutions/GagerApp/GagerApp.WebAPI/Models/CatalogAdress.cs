using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Catalog_adress")]
    public partial class CatalogAdress
    {
        public CatalogAdress()
        {
            CatalogRoom = new HashSet<CatalogRoom>();
            ZayavkaMontag = new HashSet<ZayavkaMontag>();
            ZayavkaZamer = new HashSet<ZayavkaZamer>();
        }

        [Key]
        [Column("ID_adress")]
        public long IdAdress { get; set; }
        [Required]
        [StringLength(15)]
        public string Burg { get; set; }
        [Required]
        [StringLength(30)]
        public string Ulica { get; set; }
        [Required]
        [Column("Number_dom")]
        [StringLength(30)]
        public string NumberDom { get; set; }
        [Column("Number_kvartira")]
        public int? NumberKvartira { get; set; }
        [Key]
        [Column("ID_partner")]
        public long IdPartner { get; set; }

        [ForeignKey(nameof(IdPartner))]
        [InverseProperty(nameof(CounterpartyDirectory.CatalogAdress))]
        public virtual CounterpartyDirectory IdPartnerNavigation { get; set; }
        [InverseProperty("Id")]
        public virtual ICollection<CatalogRoom> CatalogRoom { get; set; }
        [InverseProperty("Id")]
        public virtual ICollection<ZayavkaMontag> ZayavkaMontag { get; set; }
        [InverseProperty("Id")]
        public virtual ICollection<ZayavkaZamer> ZayavkaZamer { get; set; }
    }
}
