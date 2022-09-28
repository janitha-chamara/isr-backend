using ISRDataAccess.Models;
using Microsoft.EntityFrameworkCore;


namespace DataMigrations.DataModels
{
    public class ISRContext :DbContext
    {
      public DbSet<Tasks> Tasks { get; set; }
      public DbSet<Role> Roles { get; set; }
      public DbSet<LookUp> LookUps { get; set; }
      public DbSet<Job> Jobs { get; set; }
      public DbSet<EmployeeRole> EmployeeRoles { get; set; }
      public DbSet<Employee> Employees { get; set; }
      public DbSet<Client> Clients { get; set; }
      public DbSet<BusinessUnit> BusinessUnits { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=PATHUMTHINKPAD;Initial Catalog=ISR;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }
    }
}
