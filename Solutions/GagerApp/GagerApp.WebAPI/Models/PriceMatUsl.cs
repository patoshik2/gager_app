using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Price_mat_usl")]
    public partial class PriceMatUsl
    {
        [Key]
        [Column("ID_price_mat_usl")]
        public long IdPriceMatUsl { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        public double Cost { get; set; }
        [Key]
        [Column("ID_catalog")]
        public long IdCatalog { get; set; }

        [ForeignKey(nameof(IdCatalog))]
        [InverseProperty(nameof(CatalogMatUsl.PriceMatUsl))]
        public virtual CatalogMatUsl IdCatalogNavigation { get; set; }
    }
}
