using EmployeeManagement.EF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EmployeeManagement.EF.Mapping
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("EmployeeManagementConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Mapping.DepartmentMapping.Map(modelBuilder);
            Mapping.EmployeeMapping.Map(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}