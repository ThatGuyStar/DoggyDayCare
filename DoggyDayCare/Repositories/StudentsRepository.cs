namespace DoggyDayCare.Repositories
{
    using DoggyDayCare.Data;
    using DoggyDayCare.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class StudentsRepository
    {
        //Dependency Injection
        private readonly DoggyDayCareDbContext context;

        //Constructor
        public StudentsRepository(DoggyDayCareDbContext context)
        {
            this.context = context;
        }

        //Return our students table as a dbset
        public DbSet<Student> Students => context.Students;

        //Adds a student to the dbset
        public void AddStudent(Student student)
        {
            context.Students.Add(student);
        }

        //Applies changes to the database
        public async Task TryAndSaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public void DeleteStudent(Student student)
        {
            context.Entry(student).State = EntityState.Deleted;
        }

        //Call the AddStudent from the students repository
    }
}
