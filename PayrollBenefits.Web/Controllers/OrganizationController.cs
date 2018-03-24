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
    public class OrganizationController : BaseController
    {
        private readonly OrganizationLogic _organizationLogic;
        public OrganizationController(OrganizationLogic organizationLogic)
        {
            _organizationLogic = organizationLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_organizationLogic.Get(this.OrganizationId));
        }
        [HttpPut]
        public IActionResult Update([FromBody]Organization organization)
        {
            _organizationLogic.Update(this.OrganizationId, organization);
            return Ok();
        }
    }
}
