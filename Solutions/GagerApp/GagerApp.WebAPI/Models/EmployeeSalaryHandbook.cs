using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GagerApp.WebAPI.Models
{
    [Table("Employee_salary_handbook")]
    public partial class EmployeeSalaryHandbook
    {
        [Key]
        [Column("ID_employee_salary_handbook")]
        public long IdEmployeeSalaryHandbook { get; set; }
        [Column("Date_salary", TypeName = "datetime")]
        public DateTime DateSalary { get; set; }
        [Column("Sum_salary")]
        public double SumSalary { get; set; }
        [Column("Start_salary", TypeName = "datetime")]
        public DateTime StartSalary { get; set; }
        [Column("End_salary", TypeName = "datetime")]
        public DateTime EndSalary { get; set; }
        [Key]
        [Column("ID_profile_worker")]
        public long IdProfileWorker { get; set; }

        [ForeignKey(nameof(IdProfileWorker))]
        [InverseProperty(nameof(ProfileWorker.EmployeeSalaryHandbook))]
        public virtual ProfileWorker IdProfileWorkerNavigation { get; set; }
    }
}
