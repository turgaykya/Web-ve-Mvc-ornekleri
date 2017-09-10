using EmployeeManagement.EF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EmployeeManagement.EF.Mapping
{
    public class DepartmentMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Department> entity = modelBuilder.Entity<Department>();

            entity.HasKey(d => d.Id);

            //departmentConfig.Property(d => d.Name).IsRequired();
            //departmentConfig.Property(d => d.Name).HasMaxLength(50);
            entity.Property(d => d.Name).IsRequired().HasMaxLength(50);

            entity.Property(d => d.Description).HasMaxLength(500);

        }
    }
}