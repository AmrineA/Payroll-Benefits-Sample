using Microsoft.EntityFrameworkCore;
using PayrollBenefits.Models;
using System;

namespace PayrollBenefits.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dependent>().HasOne<Employee>().WithMany().HasForeignKey(u => u.EmployeeId);
            modelBuilder.Entity<Employee>().HasOne<Organization>().WithMany().HasForeignKey(u => u.OrganizationId);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
        public DbSet<Organization> Organizations { get; set; }
    }
}
