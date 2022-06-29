using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Counterparty_directory")]
    public partial class CounterpartyDirectory
    {
        public CounterpartyDirectory()
        {
            CatalogAdress = new HashSet<CatalogAdress>();
            CatalogTelNumber = new HashSet<CatalogTelNumber>();
            DirectoryLegalEntities = new HashSet<DirectoryLegalEntities>();
            EMailCatalog = new HashSet<EMailCatalog>();
            MovementGoods = new HashSet<MovementGoods>();
            SettlementsCounterparties = new HashSet<SettlementsCounterparties>();
            ZayavkaZamer = new HashSet<ZayavkaZamer>();
        }

        [Key]
        [Column("ID_partner")]
        public long IdPartner { get; set; }
        [Column("ID_customer_directory")]
        public long? IdCustomerDirectory { get; set; }

        [ForeignKey(nameof(IdCustomerDirectory))]
        [InverseProperty(nameof(CustomerDirectory.CounterpartyDirectory))]
        public virtual CustomerDirectory IdCustomerDirectoryNavigation { get; set; }
        [InverseProperty("IdPartnerNavigation")]
        public virtual ICollection<CatalogAdress> CatalogAdress { get; set; }
        [InverseProperty("IdPartnerNavigation")]
        public virtual ICollection<CatalogTelNumber> CatalogTelNumber { get; set; }
        [InverseProperty("IdPartnerNavigation")]
        public virtual ICollection<DirectoryLegalEntities> DirectoryLegalEntities { get; set; }
        [InverseProperty("IdPartnerNavigation")]
        public virtual ICollection<EMailCatalog> EMailCatalog { get; set; }
        [InverseProperty("IdPartnerNavigation")]
        public virtual ICollection<MovementGoods> MovementGoods { get; set; }
        [InverseProperty("IdPartnerNavigation")]
        public virtual ICollection<SettlementsCounterparties> SettlementsCounterparties { get; set; }
        [InverseProperty("IdPartnerNavigation")]
        public virtual ICollection<ZayavkaZamer> ZayavkaZamer { get; set; }
    }
}
