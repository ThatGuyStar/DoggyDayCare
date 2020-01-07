namespace DoggyDayCare.Services
{
    using DoggyDayCare.Repositories;
    using DoggyDayCare.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections;
    using System.Threading.Tasks;
    using DoggyDayCare.Data.Entities;
    public class TimeSheetsService : ITimeSheetsService
    {
        private readonly TimeSheetsRepository timeSheetsRepository;

        public TimeSheetsService(TimeSheetsRepository timeSheetsRepository)
        {
            this.timeSheetsRepository = timeSheetsRepository;
        }
        public async Task<ICollection> GetAllTimeSheets()
        {
            return await timeSheetsRepository.TimeSheets.ToListAsync();
        }

        public async Task AddTimeSheetAsync(TimeSheet timeSheet)
        {
            timeSheetsRepository.Add(timeSheet);
            await timeSheetsRepository.TryAndSaveChangesAsync();
        }

        public async Task<bool> DeleteTimeSheetAsync(int timeSheetId)
        {
            var dog = await timeSheetsRepository.TimeSheets.FirstOrDefaultAsync(t => t.TimeSheetId == timeSheetId);

            if (dog is null)
            {
                return false;
            }

            timeSheetsRepository.Delete(dog);
            await timeSheetsRepository.TryAndSaveChangesAsync();
            return true;
        }
    }
}
