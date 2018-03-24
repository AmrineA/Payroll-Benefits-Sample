using PayrollBenefits.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PayrollBenefits.Models;

namespace PayrollBenefits.Logic.Utilities
{
    public static class SeedLogic
    {
        public static async void InitializeDatabase(IServiceProvider services)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                await context.Database.MigrateAsync();

                if (!context.Organizations.Any())
                {
                    await context.Organizations.AddAsync(new Organization()
                    {
                        DependentBenefitsCost = 500,
                        EmployeeBenefitsCost = 1000,
                        Name = "Sample Organization",
                        PaychecksPerYear = 26
                    });
                    await context.SaveChangesAsync();
                }

                if (!context.Employees.Any())
                {
                    await context.Employees.AddAsync(new Employee()
                    {
                        Age = 30,
                        FirstName = "John",
                        LastName = "Smith",
                        OrganizationId = 1,
                        GrossPay = 2000
                    });
                    await context.SaveChangesAsync();
                }

                if (!context.Dependents.Any())
                {
                    var e = context.Employees.FirstOrDefault();

                    await context.Dependents.AddRangeAsync(new Dependent()
                    {
                        Age = 28,
                        FirstName = "Mary",
                        LastName = "Smith",
                        EmployeeId = e.Id
                    }, new Dependent()
                    {
                        Age = 13,
                        FirstName = "Amy",
                        LastName = "Smith",
                        EmployeeId = e.Id
                    }, new Dependent()
                    {
                        Age = 9,
                        FirstName = "Tyler",
                        LastName = "Smith",
                        EmployeeId = e.Id
                    });
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
