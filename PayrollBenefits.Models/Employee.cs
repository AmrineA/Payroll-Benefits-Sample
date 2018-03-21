using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PayrollBenefits.Models
{
    public class Employee : Person
    {
        [Required, MaxLength(50)]
        public string EmployeeId { get; set; }

        public decimal GrossPay { get; set; }
    }
}
