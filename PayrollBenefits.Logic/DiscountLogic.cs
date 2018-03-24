using PayrollBenefits.Logic.Discounts;
using PayrollBenefits.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PayrollBenefits.Logic
{
    public class DiscountLogic
    {
        public decimal Calculate(Person person, decimal benefits)
        {
            decimal discountTotal = 0;
            Assembly.GetExecutingAssembly().GetTypes().ToList().ForEach(t =>
            {
                if (t.GetInterface("IDiscount") != null)
                {
                    var discount = Activator.CreateInstance(t) as IDiscount;
                    discountTotal += discount.Calculate(person, benefits);
                }
            });

            return discountTotal;
        }
    }
}
