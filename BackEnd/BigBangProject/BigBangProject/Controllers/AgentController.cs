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
            try
            {
                var obj = await _agentService.GetIdByLocationName(locationName);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
