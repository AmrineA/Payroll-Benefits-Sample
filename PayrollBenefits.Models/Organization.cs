using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PayrollBenefits.Models
{
    public class Organization
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; }

        public int PaychecksPerYear { get; set; }
        public decimal EmployeeBenefitsCost { get; set; }
        public decimal DependentBenefitsCost { get; set; }
    }
}
