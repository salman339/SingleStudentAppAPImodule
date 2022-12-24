using Microsoft.EntityFrameworkCore;
using SingleStudentApp.Models;

namespace SingleStudentApp.Data
{
    // we came here from Students.cs file
    // the below class is inheriting from the dbcontext
    public class studentDbContext: DbContext
    {
        // we have created a constructor with options parameter by the above class
        public studentDbContext(DbContextOptions options) : base(options)
        {

        }

        // create a property which will be of type DbSet of type employee
        // DbSet is a type of Student which we have created in Models folder
        // The below property is basically use to create table in the database
        public DbSet<Student> Students { get; set; } 


        // after that go the appsettings.json for the creation of connection string
        // there will be ConnectionStrings object
        // After db conection string, we will inject the class dbcontenxt using the program.cs file
    }
}
