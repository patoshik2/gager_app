using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Position_smeta")]
    public partial class PositionSmeta
    {
        [Key]
        [Column("ID_position_smeta")]
        public long IdPositionSmeta { get; set; }
        public double Col { get; set; }
        [Key]
        [Column("ID_room")]
        public long IdRoom { get; set; }
        [Key]
        [Column("ID_adress")]
        public long IdAdress { get; set; }
        [Key]
        [Column("ID_catalog")]
        public long IdCatalog { get; set; }
        [Key]
        [Column("ID_partner")]
        public long IdPartner { get; set; }

        [ForeignKey("IdRoom,IdAdress,IdPartner")]
        [InverseProperty(nameof(CatalogRoom.PositionSmeta))]
        public virtual CatalogRoom Id { get; set; }
        [ForeignKey(nameof(IdCatalog))]
        [InverseProperty(nameof(CatalogMatUsl.PositionSmeta))]
        public virtual CatalogMatUsl IdCatalogNavigation { get; set; }
    }
}
