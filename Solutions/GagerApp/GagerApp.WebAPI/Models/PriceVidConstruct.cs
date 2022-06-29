using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Price_vid_construct")]
    public partial class PriceVidConstruct
    {
        [Key]
        [Column("ID_price_vid_construct")]
        public long IdPriceVidConstruct { get; set; }
        [Column("Date_cost", TypeName = "date")]
        public DateTime DateCost { get; set; }
        public double Cost { get; set; }
        [Key]
        [Column("ID_construct")]
        public long IdConstruct { get; set; }

        [ForeignKey(nameof(IdConstruct))]
        [InverseProperty(nameof(CatalogVidConstruct.PriceVidConstruct))]
        public virtual CatalogVidConstruct IdConstructNavigation { get; set; }
    }
}
