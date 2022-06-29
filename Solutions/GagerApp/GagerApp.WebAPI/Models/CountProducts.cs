using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Count_products")]
    public partial class CountProducts
    {
        [Key]
        [Column("ID_count_products")]
        public long IdCountProducts { get; set; }
        public int Count { get; set; }
        [Column("Price_move")]
        public double PriceMove { get; set; }
        [Key]
        [Column("ID_catalog")]
        public long IdCatalog { get; set; }
        [Key]
        [Column("ID_movement_doc")]
        public long IdMovementDoc { get; set; }

        [ForeignKey(nameof(IdCatalog))]
        [InverseProperty(nameof(CatalogMatUsl.CountProducts))]
        public virtual CatalogMatUsl IdCatalogNavigation { get; set; }
        [ForeignKey(nameof(IdMovementDoc))]
        [InverseProperty(nameof(MovementGoods.CountProducts))]
        public virtual MovementGoods IdMovementDocNavigation { get; set; }
    }
}
