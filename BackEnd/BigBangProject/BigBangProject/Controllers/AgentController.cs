using BigBangProject.Model;
using BigBangProject.Services.AgentService;
using Microsoft.AspNetCore.Mvc;

namespace BigBangProject.Controllers
{
    public class AgentController:ControllerBase
    {
        private readonly IAgentService _agentService;
        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }
        [HttpGet("Get LocationId")]
        public async Task<ActionResult<int?>> GetIdByLocationName(string locationName)
        {
            var obj = await _agentService.GetIdByLocationName(locationName);
            if (obj == null)
            {
                return NotFound("Cannot Display the List of Tables");
            }
            return Ok(obj);
        }
    }
}
