using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Catalog_vid_construct")]
    public partial class CatalogVidConstruct
    {
        public CatalogVidConstruct()
        {
            CatalogRoom = new HashSet<CatalogRoom>();
            PriceVidConstruct = new HashSet<PriceVidConstruct>();
        }

        [Key]
        [Column("ID_construct")]
        public long IdConstruct { get; set; }
        [Required]
        [Column("Name_construct")]
        [StringLength(13)]
        public string NameConstruct { get; set; }

        [InverseProperty("IdConstructNavigation")]
        public virtual ICollection<CatalogRoom> CatalogRoom { get; set; }
        [InverseProperty("IdConstructNavigation")]
        public virtual ICollection<PriceVidConstruct> PriceVidConstruct { get; set; }
    }
}
