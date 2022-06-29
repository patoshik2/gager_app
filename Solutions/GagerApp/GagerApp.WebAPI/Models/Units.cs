using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    public partial class Units
    {
        public Units()
        {
            CatalogMatUsl = new HashSet<CatalogMatUsl>();
        }

        [Key]
        [Column("ID_units")]
        public long IdUnits { get; set; }
        [Required]
        [StringLength(10)]
        public string Name { get; set; }
        public bool IsFloat { get; set; }

        [InverseProperty("IdUnitsNavigation")]
        public virtual ICollection<CatalogMatUsl> CatalogMatUsl { get; set; }
    }
}
