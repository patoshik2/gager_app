using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Zayavka_montag")]
    public partial class ZayavkaMontag
    {
        public ZayavkaMontag()
        {
            CatalogRoom = new HashSet<CatalogRoom>();
        }

        [Key]
        [Column("ID_montag")]
        public long IdMontag { get; set; }
        [Column("Date_montag", TypeName = "date")]
        public DateTime DateMontag { get; set; }
        [Column("Time_montag")]
        public TimeSpan TimeMontag { get; set; }
        [Column("ID_brigada")]
        public long IdBrigada { get; set; }
        [Column("ID_adress")]
        public long IdAdress { get; set; }
        [Column("ID_installation_contracts")]
        public long IdInstallationContracts { get; set; }
        [Column("ID_partner")]
        public long? IdPartner { get; set; }

        [ForeignKey("IdAdress,IdPartner")]
        [InverseProperty(nameof(CatalogAdress.ZayavkaMontag))]
        public virtual CatalogAdress Id { get; set; }
        [ForeignKey(nameof(IdBrigada))]
        [InverseProperty(nameof(CatalogBrigada.ZayavkaMontag))]
        public virtual CatalogBrigada IdBrigadaNavigation { get; set; }
        [ForeignKey(nameof(IdInstallationContracts))]
        [InverseProperty(nameof(InstallationContracts.ZayavkaMontag))]
        public virtual InstallationContracts IdInstallationContractsNavigation { get; set; }
        [InverseProperty("IdMontagNavigation")]
        public virtual ICollection<CatalogRoom> CatalogRoom { get; set; }
    }
}
