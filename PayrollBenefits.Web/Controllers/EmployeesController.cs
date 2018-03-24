using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PayrollBenefits.Logic;
using PayrollBenefits.Models;

namespace PayrollBenefits.Web.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : BaseController
    {
        private readonly EmployeeLogic _employeeLogic;
        private readonly PaySummaryLogic _paySummaryLogic;
        public EmployeesController(EmployeeLogic employeeLogic, PaySummaryLogic paySummaryLogic)
        {
            _employeeLogic = employeeLogic;
            _paySummaryLogic = paySummaryLogic;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_employeeLogic.GetAll(this.OrganizationId));
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_employeeLogic.Get(this.OrganizationId, id));
        }
        [HttpGet("{id}/PaySummary")]
        public IActionResult GetPaySummary(int id)
        {
            return Ok(_paySummaryLogic.GetPaySummary(this.OrganizationId, id));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _employeeLogic.Delete(this.OrganizationId, id);
            return Ok();
        }
        [HttpPost]
        public IActionResult Create([FromBody]Employee employee)
        {
            return Ok(_employeeLogic.Create(this.OrganizationId, employee));
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Employee employee)
        {
            _employeeLogic.Update(this.OrganizationId, id, employee);
            return Ok();
        }
    }
}
