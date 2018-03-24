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
        public EmployeesController(EmployeeLogic employeeLogic)
        {
            _employeeLogic = employeeLogic;
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
