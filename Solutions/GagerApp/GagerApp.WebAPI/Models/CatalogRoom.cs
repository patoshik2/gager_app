using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Catalog_room")]
    public partial class CatalogRoom
    {
        public CatalogRoom()
        {
            PositionSmeta = new HashSet<PositionSmeta>();
        }

        [Key]
        [Column("ID_room")]
        public long IdRoom { get; set; }
        [Required]
        [Column("Name_room")]
        [StringLength(15)]
        public string NameRoom { get; set; }
        [Column(TypeName = "image")]
        public byte[] Blueprint { get; set; }
        [Key]
        [Column("ID_adress")]
        public long IdAdress { get; set; }
        [Column("ID_construct")]
        public long IdConstruct { get; set; }
        [Column("ID_zayavka")]
        public long IdZayavka { get; set; }
        [Column("ID_montag")]
        public long? IdMontag { get; set; }
        [Key]
        [Column("ID_partner")]
        public long IdPartner { get; set; }

        [ForeignKey("IdAdress,IdPartner")]
        [InverseProperty(nameof(CatalogAdress.CatalogRoom))]
        public virtual CatalogAdress Id { get; set; }
        [ForeignKey(nameof(IdConstruct))]
        [InverseProperty(nameof(CatalogVidConstruct.CatalogRoom))]
        public virtual CatalogVidConstruct IdConstructNavigation { get; set; }
        [ForeignKey(nameof(IdMontag))]
        [InverseProperty(nameof(ZayavkaMontag.CatalogRoom))]
        public virtual ZayavkaMontag IdMontagNavigation { get; set; }
        [ForeignKey(nameof(IdZayavka))]
        [InverseProperty(nameof(ZayavkaZamer.CatalogRoom))]
        public virtual ZayavkaZamer IdZayavkaNavigation { get; set; }
        [InverseProperty("Id")]
        public virtual ICollection<PositionSmeta> PositionSmeta { get; set; }
    }
}
