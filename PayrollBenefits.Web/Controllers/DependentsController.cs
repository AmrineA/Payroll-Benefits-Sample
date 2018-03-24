using Microsoft.AspNetCore.Mvc;
using PayrollBenefits.Logic;
using PayrollBenefits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollBenefits.Web.Controllers
{
    [Route("api/Employees")]
    public class DependentsController: BaseController
    {
        private readonly DependentLogic _dependentLogic;
        public DependentsController(DependentLogic dependentLogic)
        {
            _dependentLogic = dependentLogic;
        }

        [HttpGet("{employeeId}/[controller]")]
        public IActionResult GetAll(int employeeId)
        {
            return Ok(_dependentLogic.GetAll(this.OrganizationId, employeeId));
        }
        [HttpGet("{employeeId}/[controller]/{id}")]
        public IActionResult Get(int employeeId, int id)
        {
            return Ok(_dependentLogic.Get(this.OrganizationId, employeeId, id));
        }
        [HttpDelete("{employeeId}/[controller]/{id}")]
        public IActionResult Delete(int employeeId, int id)
        {
            _dependentLogic.Delete(this.OrganizationId, employeeId, id);
            return Ok();
        }
        [HttpPost("{employeeId}/[controller]")]
        public IActionResult Create(int employeeId, Dependent dependent)
        {
            return Ok(_dependentLogic.Create(this.OrganizationId, employeeId, dependent));
        }
        [HttpPut("{employeeId}/[controller]/{id}")]
        public IActionResult Update(int employeeId, int id, Dependent dependent)
        {
            _dependentLogic.Update(this.OrganizationId, employeeId, id, dependent);
            return Ok();
        }
    }
}
