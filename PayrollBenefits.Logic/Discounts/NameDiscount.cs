using System;
using System.Collections.Generic;
using System.Text;
using PayrollBenefits.Models;

namespace PayrollBenefits.Logic.Discounts
{
    public class NameDiscount : IDiscount
    {
        public decimal Calculate(Person person, decimal benefits)
        {
            if (person.FirstName.StartsWith("A", StringComparison.OrdinalIgnoreCase)
                || person.LastName.StartsWith("A", StringComparison.OrdinalIgnoreCase))
            {
                return 0.1M * benefits;
            }

            return 0;
        }
    }
}
