using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Settlements_counterparties")]
    public partial class SettlementsCounterparties
    {
        [Key]
        [Column("Settlements_counterparties")]
        public long SettlementsCounterparties1 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Column("Sum_settlements_counterparties")]
        public double SumSettlementsCounterparties { get; set; }
        [Column("Arrival_expense")]
        public bool ArrivalExpense { get; set; }
        [Column("Cash_payment")]
        public bool CashPayment { get; set; }
        [Column("ID_installation_contracts")]
        public long? IdInstallationContracts { get; set; }
        [Key]
        [Column("ID_partner")]
        public long IdPartner { get; set; }

        [ForeignKey(nameof(IdInstallationContracts))]
        [InverseProperty(nameof(InstallationContracts.SettlementsCounterparties))]
        public virtual InstallationContracts IdInstallationContractsNavigation { get; set; }
        [ForeignKey(nameof(IdPartner))]
        [InverseProperty(nameof(CounterpartyDirectory.SettlementsCounterparties))]
        public virtual CounterpartyDirectory IdPartnerNavigation { get; set; }
    }
}
