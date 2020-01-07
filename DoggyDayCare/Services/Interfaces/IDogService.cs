namespace DoggyDayCare.Services.Interfaces
{
    using System.Collections;
    using System.Threading.Tasks;
    using DoggyDayCare.Data.Entities;

    public interface IDogService
    {
        Task<ICollection> GetAllDogs();

        Task AddDogAsync(Dog dog);

        Task<bool> DeleteDogAsync(int dogId);

        //Task DeleteDog(int dogId);

        //Task UpdateDog(int dogId);
    }
}
