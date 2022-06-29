using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Catalog_brigada")]
    public partial class CatalogBrigada
    {
        public CatalogBrigada()
        {
            ProfileWorker = new HashSet<ProfileWorker>();
            ZayavkaMontag = new HashSet<ZayavkaMontag>();
        }

        [Key]
        [Column("ID_brigada")]
        public long IdBrigada { get; set; }

        [InverseProperty("IdBrigadaNavigation")]
        public virtual ICollection<ProfileWorker> ProfileWorker { get; set; }
        [InverseProperty("IdBrigadaNavigation")]
        public virtual ICollection<ZayavkaMontag> ZayavkaMontag { get; set; }
    }
}
