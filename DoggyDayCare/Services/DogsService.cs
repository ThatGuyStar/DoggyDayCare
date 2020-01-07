namespace DoggyDayCare.Services
{
    using DoggyDayCare.Repositories;
    using DoggyDayCare.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections;
    using System.Threading.Tasks;
    using DoggyDayCare.Data.Entities;

    public class DogsService : IDogService
    {
        private readonly DogsRepository dogsRepository;

        public DogsService(DogsRepository dogsRepository)
        {
            this.dogsRepository = dogsRepository;
        }

        public async Task<ICollection> GetAllDogs()
        {
            return await dogsRepository.Dogs.ToListAsync();
        }

        public async Task AddDogAsync(Dog dog)
        {
            dogsRepository.Add(dog);
            await dogsRepository.TryAndSaveChangesAsync();
        }

        public async Task<bool> DeleteDogAsync(int dogId)
        {
            var dog = await dogsRepository.Dogs.FirstOrDefaultAsync(d => d.DogId == dogId);

            if (dog is null)
            {
                return false;
            }

            dogsRepository.Delete(dog);
            await dogsRepository.TryAndSaveChangesAsync();
            return true;
        }
    }
}
