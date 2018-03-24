using PayrollBenefits.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollBenefits.Logic.Discounts
{
    public interface IDiscount
    {
        decimal Calculate(Person person, decimal benefits);
    }
}
