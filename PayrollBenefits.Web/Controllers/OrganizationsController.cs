using Microsoft.AspNetCore.Mvc;
using PayrollBenefits.Logic;
using PayrollBenefits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollBenefits.Web.Controllers
{
    [Route("api/[controller]")]
    public class OrganizationsController : BaseController
    {
        private readonly OrganizationLogic _organizationLogic;
        public OrganizationsController(OrganizationLogic organizationLogic)
        {
            _organizationLogic = organizationLogic;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_organizationLogic.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_organizationLogic.Get(this.OrganizationId));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _organizationLogic.Delete(this.OrganizationId);
            return Ok();
        }
        [HttpPost]
        public IActionResult Create(Organization organization)
        {
            return Ok(_organizationLogic.Create(organization));
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Organization organization)
        {
            _organizationLogic.Update(this.OrganizationId, organization);
            return Ok();
        }
    }
}
