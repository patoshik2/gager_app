using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Customer_directory")]
    public partial class CustomerDirectory
    {
        public CustomerDirectory()
        {
            CatalogCartClient = new HashSet<CatalogCartClient>();
            CounterpartyDirectory = new HashSet<CounterpartyDirectory>();
        }

        [Key]
        [Column("ID_customer_directory")]
        public long IdCustomerDirectory { get; set; }
        [Required]
        [Column("Surname_client")]
        [StringLength(30)]
        public string SurnameClient { get; set; }
        [Required]
        [Column("Name_client")]
        [StringLength(15)]
        public string NameClient { get; set; }
        [Required]
        [Column("Paternum_client")]
        [StringLength(30)]
        public string PaternumClient { get; set; }
        [Column("ID_Directory_legal_entities")]
        public long? IdDirectoryLegalEntities { get; set; }

        [ForeignKey(nameof(IdDirectoryLegalEntities))]
        [InverseProperty(nameof(DirectoryLegalEntities.CustomerDirectory))]
        public virtual DirectoryLegalEntities IdDirectoryLegalEntitiesNavigation { get; set; }
        [InverseProperty("IdCustomerDirectoryNavigation")]
        public virtual ICollection<CatalogCartClient> CatalogCartClient { get; set; }
        [InverseProperty("IdCustomerDirectoryNavigation")]
        public virtual ICollection<CounterpartyDirectory> CounterpartyDirectory { get; set; }
    }
}
