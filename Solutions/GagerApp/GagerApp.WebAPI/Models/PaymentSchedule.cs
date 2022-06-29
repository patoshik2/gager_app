using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Payment_schedule")]
    public partial class PaymentSchedule
    {
        [Key]
        [Column("ID_payment_schedule")]
        public long IdPaymentSchedule { get; set; }
        [Column("Date_payment_schedule", TypeName = "datetime")]
        public DateTime DatePaymentSchedule { get; set; }
        [Column("Sum_payment_schedule")]
        public double SumPaymentSchedule { get; set; }
        [Key]
        [Column("ID_installation_contracts")]
        public long IdInstallationContracts { get; set; }

        [ForeignKey(nameof(IdInstallationContracts))]
        [InverseProperty(nameof(InstallationContracts.PaymentSchedule))]
        public virtual InstallationContracts IdInstallationContractsNavigation { get; set; }
    }
}
