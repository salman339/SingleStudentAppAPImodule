using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SingleStudentApp.Data;
using SingleStudentApp.Models;

namespace SingleStudentApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // We have defined the route for the controller
    public class StudentsController: Controller
    {
        // we will assign this private variable to the inside of the constructor 
        private readonly studentDbContext _studentDbContext;
        // Now we will make a controller to inject our Dbcontext which we have created in Program.cs
        public StudentsController(studentDbContext studentContext)
        {

            _studentDbContext = studentContext; // we have declared the variable with the underscore and private readonly

        }


        // First method is the HTTPGet method to get all the Students
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            // Now we will talk to our database using the private local variable

         var students = await  _studentDbContext.Students.ToListAsync(); // we have converted our result to list using async method

            // If we use async in the method defination we will use await 

            // then we must return
            return Ok(students);

        }

        [HttpPost]
        // we will use fromBody parameter with student model and will give it a name studentRequest
        public async Task<IActionResult> AddStudent([FromBody] Student studentRequest)
        {
            // when we will get studentRequest we will create a new new id through api because we dont trust angular
          
                studentRequest.Id = Guid.NewGuid();

            
           // we will add the request of student to the dbcontext using the below code

            await _studentDbContext.Students.AddAsync(studentRequest);

            // Now we also need to save the changes, we will SaveChangesAsync method
            await _studentDbContext.SaveChangesAsync();

            // after the saving changes we will send the Ok response after the newly created student
            return Ok(studentRequest);
        }

        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid id)
        {
           var student = await _studentDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

            if(student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }


        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> UpdateStudent([FromRoute] Guid id, Student UpdateStudentRequest)
        {
            var student = await _studentDbContext.Students.FindAsync(id);
            if(student == null)
            {
                return NotFound();
            }
            student.Id = id;    
            student.FirstName= UpdateStudentRequest.FirstName;
            student.LastName= UpdateStudentRequest.LastName;
            student.Email= UpdateStudentRequest.Email;
            student.DateOfBirth= UpdateStudentRequest.DateOfBirth;

            await _studentDbContext.SaveChangesAsync();

            return Ok(student);
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> DeleteStudentAsync(Guid id)
        {
            var studentDelete = await _studentDbContext.Students.FindAsync(id);
            if (studentDelete != null)
            {
                 _studentDbContext.Students.Remove(studentDelete);
                await _studentDbContext.SaveChangesAsync();
                return Ok(studentDelete);

            }

            return NotFound();


        }

    }
}
