using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PayrollBenefits.Models
{
    public class Employee : Person
    {
        public decimal GrossPay { get; set; }

        public int OrganizationId { get; set; }
    }
}
