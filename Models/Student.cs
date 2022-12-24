namespace SingleStudentApp.Models
{
    public class Student
    {

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        // if we are using .net six it will give us notice about the null value on strings
        // click on the project twice and make the nullable disable, now it is enable
        // after disabling that, we will not get the nullable property issue

       // These names should match with the angular application names

        //** after this we need to create Dbcontext to talk to our database
        // we will create a new folder called Data and in that we will create a class named studentDbContext
    }
}
