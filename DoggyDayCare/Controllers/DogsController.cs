namespace DoggyDayCare.Controllers
{
    using DoggyDayCare.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using DoggyDayCare.Data.Entities;

    [Route("api/dogs")]
    public class DogsController : ControllerBase
    {
        private readonly IDogService dogsService;

        public DogsController(IDogService dogService)
        {
            this.dogsService = dogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDogs()
        {
            return Ok(await dogsService.GetAllDogs());
        }

        [HttpPost]
        public async Task<IActionResult> AddDog([FromBody] Dog dog)
        {
            await dogsService.AddDogAsync(dog);
            return Ok();
        }

        [Route("{dogId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteDog([FromRoute] int dogId)
        {
            await dogsService.DeleteDogAsync(dogId);
            return Ok();
            //var result = await dogsService.DeleteDog(dogId);

            //if (result.Reason != null)
            //{
            //    return BadRequest(result);
            //}

            //return Ok();
        }
    }
}
