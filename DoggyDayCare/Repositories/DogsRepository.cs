namespace DoggyDayCare.Repositories
{
    using System.Threading.Tasks;
    using Data;
    using Data.Entities;
    using Microsoft.EntityFrameworkCore;
    public class DogsRepository
    {
        private readonly DoggyDayCareDbContext context;

        public DogsRepository(DoggyDayCareDbContext context)
        {
            this.context = context;
        }

        public DbSet<Dog> Dogs => context.Dogs;

        public void Add(Dog dog)
        {
            context.Add(dog);
        }

        public void Delete(Dog dog)
        {
            context.Entry(dog).State = EntityState.Deleted;
        }

        public void Update(Dog dog)
        {
            context.Entry(dog).State = EntityState.Modified;
        }

        public async Task TryAndSaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
