using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollBenefits.Models
{
    public class PaySummaryItem
    {
        public string Item { get; set; }
        public decimal Subtotal { get; set; }
        public decimal? Discount { get; set; }
        public decimal Total { get
            {
                return Subtotal + (Discount ?? 0);
            }
        }
    }
}
