using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Catalog_cart_client")]
    public partial class CatalogCartClient
    {
        [Key]
        [Column("ID_cart_client")]
        public long IdCartClient { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }
        [Column("ID_customer_directory")]
        public long? IdCustomerDirectory { get; set; }

        [ForeignKey(nameof(IdCustomerDirectory))]
        [InverseProperty(nameof(CustomerDirectory.CatalogCartClient))]
        public virtual CustomerDirectory IdCustomerDirectoryNavigation { get; set; }
    }
}
