using Microsoft.EntityFrameworkCore;
using PayrollBenefits.Data;
using PayrollBenefits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollBenefits.Logic
{
    public class OrganizationLogic
    {
        private readonly DataContext _dataContext;
        public OrganizationLogic(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Organization> GetAll()
        {
            return _dataContext.Organizations.ToList();
        }

        public Organization Get(int id)
        {
            return _dataContext.Organizations.FirstOrDefault(o => o.Id == id);
        }

        public Organization Create(Organization organization)
        {
            _dataContext.Organizations.Add(organization);
            return organization;
        }

        public void Update(int id, Organization organization)
        {
            organization.Id = id;
            _dataContext.Organizations.Update(organization);
        }

        public void Delete(int id)
        {
            var organization = Get(id);
            _dataContext.Organizations.Remove(organization);
        }
    }
}
