namespace DoggyDayCare.Services.Interfaces
{
    using DoggyDayCare.Data.Entities;
    using System.Collections;
    using System.Threading.Tasks;
    public interface ITimeSheetsService
    {
        Task<ICollection> GetAllTimeSheets();

        Task AddTimeSheetAsync(TimeSheet timeSheet);

        Task<bool> DeleteTimeSheetAsync(int timeSheetId);
    }
}
