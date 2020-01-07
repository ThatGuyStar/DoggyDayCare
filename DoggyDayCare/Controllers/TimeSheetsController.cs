namespace DoggyDayCare.Controllers
{
    using DoggyDayCare.Data.Entities;
    using DoggyDayCare.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/timesheets")]
    public class TimeSheetsController : ControllerBase
    {
        private readonly ITimeSheetsService timeSheetsService;

        public TimeSheetsController(ITimeSheetsService timeSheetsService)
        {
            this.timeSheetsService = timeSheetsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTimeSheets()
        {
            return Ok(await timeSheetsService.GetAllTimeSheets());
        }

        [HttpPost]
        public async Task<IActionResult> AddTimeSheet([FromBody] TimeSheet timeSheet)
        {
            await timeSheetsService.AddTimeSheetAsync(timeSheet);
            return Ok();
        }
    }
}
