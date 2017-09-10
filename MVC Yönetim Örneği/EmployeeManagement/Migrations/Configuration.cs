namespace EmployeeManagement.Migrations
{
    using EmployeeManagement.EF.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeManagement.EF.Mapping.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EmployeeManagement.EF.Mapping.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            Department yazilimDepartment = new Department() { Name = "Yazýlým", Description = "Yazýlým proje geliþtirme" };
            Department sistemDepartment = new Department() { Name = "Sistem", Description = "Sistem, Güvenlik, Network" };
            context.Departments.AddOrUpdate(
                d => d.Name,
                yazilimDepartment,
                sistemDepartment
                );

            context.Employee.AddOrUpdate(
                e => e.FirstName,
                new Employee() { FirstName = "Tusubasa", LastName = "ozora", Department = yazilimDepartment, Salary = 1800, Gender = Gender.Male, EmailAddress = "tusubasa@ozora.com" },
                new Employee() { FirstName = "Misaki", LastName = "Taro", Department = sistemDepartment, Salary = 1450, EmailAddress = "misaki@taro.com" },
                 new Employee() { FirstName = "asd", LastName = "asdsa", Department = sistemDepartment, Salary = 1450, EmailAddress = "misaki@taro.com", PhoneNumber = "123456789" }
                );
        }
    }
}
