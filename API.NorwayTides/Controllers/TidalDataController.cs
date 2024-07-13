using API.NorwayTides.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.NorwayTides.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TidalDataController : ControllerBase
    {
        private readonly TidalDataService _tidalDataService;

        public TidalDataController(TidalDataService tidalDataService)
        {
            _tidalDataService = tidalDataService;
        }

        [HttpGet("AvailableHarbors")]
        public async Task<IActionResult> GetAvailableHarbors()
        {
            try
            {
                var harbors = await _tidalDataService.GetAvailableHarborsAsync();
                return Ok(harbors);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex}");
                return StatusCode(500, "An error occurred while fetching available harbors.");

            }
        }
    }
}
