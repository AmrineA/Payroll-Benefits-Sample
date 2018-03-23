using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollBenefits.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        public int OrganizationId {
            get
            {
                // Should pull from a user claim after the user is authenticated
                return 1;
            }
        }
    }
}
