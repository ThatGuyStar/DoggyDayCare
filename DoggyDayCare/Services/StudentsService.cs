namespace DoggyDayCare.Services
{
    using DoggyDayCare.Data.Entities;
    using DoggyDayCare.Repositories;
    using DoggyDayCare.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections;
    using System.Threading.Tasks;
    public class StudentsService : IStudentService
    {
        //inject repository file
        private readonly StudentsRepository studentsRepository;

        //Constructor 
        public StudentsService(StudentsRepository studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }

        //Calls the method in repository class
        public async Task<ICollection> GetAllStudents()
        {
            return await studentsRepository.Students.ToListAsync();
        }

        public async Task AddStudentAsync(Student student)
        {
            studentsRepository.AddStudent(student);
            await studentsRepository.TryAndSaveChangesAsync();
        }

        //provides error checking
        //Chekcs to see if the student with that id exists
        public async Task<bool> DeleteStudentAsync(string studentId)
        {
            //Firstordefaultasync
            //returns first student it finds with that id or null
            //letter is the student object
            var student = await studentsRepository.Students.FirstOrDefaultAsync(s => s.StudentId == studentId);

            if (student is null)
            {
                //returns a bad request
                return false;
            }

            studentsRepository.DeleteStudent(student);
            await studentsRepository.TryAndSaveChangesAsync();
            //returns ok if true
            return true;
        }
    }
}
