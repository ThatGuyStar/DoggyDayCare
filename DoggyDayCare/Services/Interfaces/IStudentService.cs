namespace DoggyDayCare.Services.Interfaces
{
    using DoggyDayCare.Data.Entities;
    using System.Collections;
    using System.Threading.Tasks;

    public interface IStudentService
    {
        Task<ICollection> GetAllStudents();

        Task AddStudentAsync(Student student);

        Task<bool> DeleteStudentAsync(string studentId);

    }
}
