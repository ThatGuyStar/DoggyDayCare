namespace DoggyDayCare.Repositories
{
    using System.Threading.Tasks;
    using Data;
    using Data.Entities;
    using Microsoft.EntityFrameworkCore;
    public class TimeSheetsRepository
    {
        private readonly DoggyDayCareDbContext context;

        public TimeSheetsRepository(DoggyDayCareDbContext context)
        {
            this.context = context;
        }

        public DbSet<TimeSheet> TimeSheets => context.TimeSheets;

        public void Add(TimeSheet timeSheet)
        {
            context.Add(timeSheet);
        }

        public void Delete(TimeSheet timeSheet)
        {
            context.Entry(timeSheet).State = EntityState.Deleted;
        }

        public void Update(TimeSheet timeSheet)
        {
            context.Entry(timeSheet).State = EntityState.Modified;
        }

        public async Task TryAndSaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}