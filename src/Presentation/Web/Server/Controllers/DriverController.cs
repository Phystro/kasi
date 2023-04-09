using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly DriverService _service;

        public DriverController(DriverService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Driver>>> GetAsync()
        {
            IEnumerable<Driver> drivers = await _service.QueryAsync();
            
            return Ok(drivers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> GetAsync(int id)
        {
            Driver? driver = await _service.ReadAsync(id);

            if(driver is null) return NotFound();

            return Ok(driver);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Driver request)
        {
            Driver driver = await _service.CreateAsync(request);

            return CreatedAtAction( nameof(GetAsync), driver, driver.Id );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateASync(Driver request, int id)
        {
            if(id != request.Id) return BadRequest();

            Driver? driver = await _service.UpdateAsync(request);

            if(driver is null) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool result = await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}