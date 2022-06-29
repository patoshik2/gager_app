using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Directory_ legal_entities")]
    public partial class DirectoryLegalEntities
    {
        public DirectoryLegalEntities()
        {
            CustomerDirectory = new HashSet<CustomerDirectory>();
        }

        [Key]
        [Column("ID_Directory_legal_entities")]
        public long IdDirectoryLegalEntities { get; set; }
        [Required]
        [Column("Name_company")]
        [StringLength(30)]
        public string NameCompany { get; set; }
        [Required]
        [Column("Full_name_company")]
        [StringLength(30)]
        public string FullNameCompany { get; set; }
        public int Inn { get; set; }
        [Column("ID_partner")]
        public long? IdPartner { get; set; }

        [ForeignKey(nameof(IdPartner))]
        [InverseProperty(nameof(CounterpartyDirectory.DirectoryLegalEntities))]
        public virtual CounterpartyDirectory IdPartnerNavigation { get; set; }
        [InverseProperty("IdDirectoryLegalEntitiesNavigation")]
        public virtual ICollection<CustomerDirectory> CustomerDirectory { get; set; }
    }
}
