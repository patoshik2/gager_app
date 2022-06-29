using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Catalog_mat_usl")]
    public partial class CatalogMatUsl
    {
        public CatalogMatUsl()
        {
            CountProducts = new HashSet<CountProducts>();
            PositionSmeta = new HashSet<PositionSmeta>();
            PriceMatUsl = new HashSet<PriceMatUsl>();
        }

        [Key]
        [Column("ID_catalog")]
        public long IdCatalog { get; set; }
        [Required]
        [Column("Name_mat_usl")]
        [StringLength(150)]
        public string NameMatUsl { get; set; }
        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
        [Column("Last_closing_date", TypeName = "datetime")]
        public DateTime LastClosingDate { get; set; }
        [Column("residual")]
        public double Residual { get; set; }
        [Column("ID_units")]
        public long IdUnits { get; set; }
        [Column("ID_type_mat_usl")]
        public long IdTypeMatUsl { get; set; }

        [ForeignKey(nameof(IdTypeMatUsl))]
        [InverseProperty(nameof(TypeMatUsl.CatalogMatUsl))]
        public virtual TypeMatUsl IdTypeMatUslNavigation { get; set; }
        [ForeignKey(nameof(IdUnits))]
        [InverseProperty(nameof(Units.CatalogMatUsl))]
        public virtual Units IdUnitsNavigation { get; set; }
        [InverseProperty("IdCatalogNavigation")]
        public virtual ICollection<CountProducts> CountProducts { get; set; }
        [InverseProperty("IdCatalogNavigation")]
        public virtual ICollection<PositionSmeta> PositionSmeta { get; set; }
        [InverseProperty("IdCatalogNavigation")]
        public virtual ICollection<PriceMatUsl> PriceMatUsl { get; set; }
    }
}
