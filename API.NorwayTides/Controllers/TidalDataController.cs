using API.NorwayTides.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.NorwayTides.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TidalDataController : ControllerBase
    {
        private readonly TidalDataService _tidalDataService;
        private readonly ILogger<TidalDataController> _logger;

        public TidalDataController(TidalDataService tidalDataService, ILogger<TidalDataController> logger)
        {
            _tidalDataService = tidalDataService;
            _logger = logger;
        }

        [HttpGet("AvailableHarbors")]
        public async Task<IActionResult> GetAvailableHarbors()
        {
            try
            {
                var harbors = await _tidalDataService.GetAvailableHarborsAsync();
                return Ok(harbors);
            }
            catch
            {
                return StatusCode(500, "An error occurred while fetching available harbors.");
            }
        }

        [HttpGet("Harbor/{harborName}")]
        public async Task<IActionResult> GetHarborData(string harborName)
        {
            try
            {
                var harborData = await _tidalDataService.GetHarborDataAsync(harborName);
                return Ok(harborData);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error occurred while fetching tidal data for {Harbor}", harborName);


                return StatusCode(500, $"An error occurred while fetching tidal data for {harborName}: {ex.Message}");
            }
        }
    }
}
