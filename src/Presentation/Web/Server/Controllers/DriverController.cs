using Microsoft.AspNetCore.Mvc;

namespace Kasi.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _service;
        private readonly ILogger<DriverController> _logger;

        public DriverController(IDriverService service, ILogger<DriverController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriverResponse>>> GetAsync()
        {
            _logger.LogInformation("[ + ] GetAsync");
            IEnumerable<DriverResponse> drivers = await _service.QueryAsync();
            
            return Ok(drivers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DriverResponse>> GetAsync(string id)
        {
            DriverResponse? driver = await _service.ReadAsync(id);

            if(driver is null) return NotFound();

            return Ok(driver);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(DriverRequest request)
        {
            DriverResponse driverResponse = await _service.CreateAsync(request);

            return CreatedAtAction( "Get", driverResponse, driverResponse.Id );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateASync(DriverRequest request, string id)
        {
            // if(id != request.Id) return BadRequest();

            DriverResponse? driver = await _service.UpdateAsync(id, request);

            if(driver is null) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            bool result = await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}
