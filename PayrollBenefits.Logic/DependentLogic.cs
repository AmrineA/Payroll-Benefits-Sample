using PayrollBenefits.Data;
using PayrollBenefits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayrollBenefits.Logic
{
    public class DependentLogic
    {
        private readonly DataContext _dataContext;
        private readonly EmployeeLogic _employeeLogic;
        public DependentLogic(DataContext dataContext, EmployeeLogic employeeLogic)
        {
            _dataContext = dataContext;
            _employeeLogic = employeeLogic;
        }

        public List<Dependent> GetAll(int organizationId, int employeeId)
        {
            return (from d in _dataContext.Dependents
                    join e in _dataContext.Employees on d.EmployeeId equals e.Id
                    where e.OrganizationId == organizationId && e.Id == employeeId
                    select d).ToList();
        }

        public Dependent Get(int organizationId, int employeeId, int id)
        {
            return (from d in _dataContext.Dependents
                    join e in _dataContext.Employees on d.EmployeeId equals e.Id
                    where e.OrganizationId == organizationId && e.Id == employeeId && d.Id == id
                    select d).FirstOrDefault();
        }

        public Dependent Create(int organizationId, int employeeId, Dependent dependent)
        {
            if (_employeeLogic.Get(organizationId, employeeId) == null)
            {
                return null;
            }
            else
            {
                dependent.EmployeeId = employeeId;
                _dataContext.Dependents.Add(dependent);
                _dataContext.SaveChanges();
                return dependent;
            }
        }

        public void Update(int organizationId, int employeeId, int id, Dependent dependent)
        {
            var dep = Get(organizationId, employeeId, id);
            if (dep != null)
            {
                dep.Age = dependent.Age;
                dep.FirstName = dependent.FirstName;
                dep.LastName = dependent.LastName;
                _dataContext.SaveChanges();
            }
        }

        public void Delete(int organizationId, int employeeId, int id)
        {
            var dependent = Get(organizationId, employeeId, id);
            _dataContext.Dependents.Remove(dependent);
            _dataContext.SaveChanges();
        }
    }
}
