using Microsoft.AspNetCore.Mvc;

namespace Kasi.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _service;
        private readonly ILogger<TeamController> _logger;

        public TeamController(ITeamService service, ILogger<TeamController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamResponse>>> GetAsync()
        {
            _logger.LogInformation("[ + ] GetAsync");
            IEnumerable<TeamResponse> teams = await _service.QueryAsync();
            
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamResponse>> GetAsync(string id)
        {
            TeamResponse? team = await _service.ReadAsync(id);

            if(team is null) return NotFound();

            return Ok(team);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(TeamRequest request)
        {
            TeamResponse team = await _service.CreateAsync(request);

            return CreatedAtAction( "Get", team, team.Id );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateASync(TeamRequest request, string id)
        {
            // if(id != request.Id) return BadRequest();

            TeamResponse? team = await _service.UpdateAsync(id, request);

            if(team is null) return NotFound();

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