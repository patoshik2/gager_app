using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Installation_contracts")]
    public partial class InstallationContracts
    {
        public InstallationContracts()
        {
            PaymentSchedule = new HashSet<PaymentSchedule>();
            SettlementsCounterparties = new HashSet<SettlementsCounterparties>();
            ZayavkaMontag = new HashSet<ZayavkaMontag>();
        }

        [Key]
        [Column("ID_installation_contracts")]
        public long IdInstallationContracts { get; set; }
        [Column("Number_contracts")]
        public int NumberContracts { get; set; }
        [Column("Date_Installation_contracts", TypeName = "datetime")]
        public DateTime DateInstallationContracts { get; set; }
        [Column("Sum_for_pay")]
        public double SumForPay { get; set; }
        [Column("Tipe_pay")]
        public bool TipePay { get; set; }
        [Column("count_months")]
        public int? CountMonths { get; set; }
        public double Discount { get; set; }

        [InverseProperty("IdInstallationContractsNavigation")]
        public virtual ICollection<PaymentSchedule> PaymentSchedule { get; set; }
        [InverseProperty("IdInstallationContractsNavigation")]
        public virtual ICollection<SettlementsCounterparties> SettlementsCounterparties { get; set; }
        [InverseProperty("IdInstallationContractsNavigation")]
        public virtual ICollection<ZayavkaMontag> ZayavkaMontag { get; set; }
    }
}
