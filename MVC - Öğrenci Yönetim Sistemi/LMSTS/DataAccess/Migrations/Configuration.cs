namespace DataAccess.Migrations
{
    using _01_Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.LMSTSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccess.LMSTSContext context)
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

            Gender erkek = new Gender(){ Name= "Erkek"};
              Gender kadin = new Gender(){ Name= "Kadýn"};


            EducationBranch sayisal = new EducationBranch(){Name="Sayýsal"} ;
                 EducationBranch sozel = new EducationBranch(){Name="Sözel"} ;
                 EducationBranch esitAgirlik = new EducationBranch(){Name="Eþit Aðýrlýk"} ;

                 //context.Student.AddOrUpdate(
                 //       s => s.FirstName,
                 //        erkek,
                 //        kadin
                 //    );

                 context.Student.AddOrUpdate(
                     s=>s.FirstName,
                     new Student()
                     {
                         FirstName = "Ayça",
                         LastName = "Calayýr",
                         Gender = kadin,
                         DateOfBirth = DateTime.Parse("15.10.1992"),
                         EducationBranch = sayisal,
                         DateOfRegistration = DateTime.Parse("23.11.2016"),
                         IsOnline = false,
                         Status = true
                     });
       

        }
    }
}
