using PayrollBenefits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayrollBenefits.Logic
{
    public class PaySummaryLogic
    {
        private readonly EmployeeLogic _eLogic;
        private readonly DependentLogic _dLogic;
        private readonly OrganizationLogic _oLogic;
        private readonly DiscountLogic _discountLogic;
        public PaySummaryLogic(EmployeeLogic eLogic, DependentLogic dLogic, OrganizationLogic oLogic,
            DiscountLogic discountLogic)
        {
            this._eLogic = eLogic;
            this._dLogic = dLogic;
            this._oLogic = oLogic;
            this._discountLogic = discountLogic;
        }
        public List<PaySummaryItem> GetPaySummary(int organizationId, int employeeId)
        {
            var org = _oLogic.Get(organizationId);
            var emp = _eLogic.Get(organizationId, employeeId);
            var deps = _dLogic.GetAll(organizationId, employeeId);
            var summary = new List<PaySummaryItem>();

            //Add the gross pay
            summary.Add(new PaySummaryItem()
            {
                Item = "Gross Pay",
                Subtotal = emp.GrossPay
            });

            //Subtract out benefits
            decimal employeeBenefits = org.EmployeeBenefitsCost / org.PaychecksPerYear;
            summary.Add(new PaySummaryItem()
            {
                Item = string.Format("Employee Benefits - {0} {1}", emp.FirstName, emp.LastName),
                Subtotal = -employeeBenefits,
                Discount = _discountLogic.Calculate(emp, employeeBenefits)
            });

            deps.ForEach(d =>
            {
                decimal dependentBenefits = org.DependentBenefitsCost / org.PaychecksPerYear;
                summary.Add(new PaySummaryItem()
                {
                    Item = string.Format("Dependent Benefits - {0} {1}", d.FirstName, d.LastName),
                    Subtotal = -dependentBenefits,
                    Discount = _discountLogic.Calculate(d, dependentBenefits)
                });
            });

            //Add the total item
            summary.Add(new PaySummaryItem()
            {
                Item = "Total",
                Subtotal = summary.Sum(s => s.Subtotal),
                Discount = summary.Sum(s => s.Discount)
            });


            return summary;
        }
    }
}
