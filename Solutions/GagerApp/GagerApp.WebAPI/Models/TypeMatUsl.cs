using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Type_mat_usl")]
    public partial class TypeMatUsl
    {
        public TypeMatUsl()
        {
            CatalogMatUsl = new HashSet<CatalogMatUsl>();
        }

        [Key]
        [Column("ID_type_mat_usl")]
        public long IdTypeMatUsl { get; set; }
        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [InverseProperty("IdTypeMatUslNavigation")]
        public virtual ICollection<CatalogMatUsl> CatalogMatUsl { get; set; }
    }
}
