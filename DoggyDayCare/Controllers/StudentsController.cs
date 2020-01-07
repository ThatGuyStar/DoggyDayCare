namespace DoggyDayCare.Controllers
{
    using DoggyDayCare.Data.Entities;
    using DoggyDayCare.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            //Return an action result
            return Ok(await studentService.GetAllStudents());
        }

        //FromBody means student object is going to be contained in the body of the request
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            await studentService.AddStudentAsync(student);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(string studentId)
        {
            await studentService.DeleteStudentAsync(studentId);
            return Ok();
        }
    }
    
}
//HttpGet – Retrieval
//HttpPost – Creation
//HttpPatch – Updating 
//HttpDelete – Deleting