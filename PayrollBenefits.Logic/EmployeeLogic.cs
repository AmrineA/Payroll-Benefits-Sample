using PayrollBenefits.Data;
using PayrollBenefits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayrollBenefits.Logic
{
    public class EmployeeLogic
    {
        private readonly DataContext _dataContext;
        public EmployeeLogic(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Employee> GetAll(int organizationId)
        {
            return _dataContext.Employees.Where(e => e.OrganizationId == organizationId).ToList();
        }

        public Employee Get(int organizationId, int id)
        {
            return _dataContext.Employees.FirstOrDefault(e => e.OrganizationId == organizationId && e.Id == id);
        }

        public Employee Create(int organizationId, Employee employee)
        {
            employee.OrganizationId = organizationId;
            _dataContext.Employees.Add(employee);
            return employee;
        }

        public void Update(int organizationId, int id, Employee employee)
        {
            employee.OrganizationId = organizationId;
            employee.Id = id;
            _dataContext.Employees.Update(employee);
        }

        public void Delete(int organizationId, int id)
        {
            var employee = Get(organizationId, id);
            _dataContext.Employees.Remove(employee);
        }
    }
}
