using BigBangProject.Model;
using BigBangProject.Services.AgentService;
using Microsoft.AspNetCore.Mvc;

namespace BigBangProject.Controllers
{
    [Route("AgentSide")]
    [ApiController]
    public class AgentController:ControllerBase
    {
        private readonly IAgentService _agentService;
        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }
        [HttpGet("GetLocationId")]
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
        [HttpGet("GetSpotNameById")]
        public async Task<ActionResult<List<SightSeeing>>> GetSpotbyLocationId(int locationId)
        {
            try
            {
                var obj = await _agentService.GetSpotbyLocationId(locationId);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetHotelNameBySpotId")]
        public async Task<ActionResult<List<Hotel>>> GetHotelbySpotId(int  locationId)
        {
            try
            {
                var obj = await _agentService.GetHotelbySpotId(locationId);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("PostPackage")]
        public async Task<ActionResult<List<Package>>> PostPackage(Package package)
        {
            try
            {
                var obj = await _agentService.PostPackage(package);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("GetHotelNameBySpotId")]
        public async Task<ActionResult<List<DaySchedule>>> PostDaySchedule(DaySchedule daySchedule)
        {
            try
            {
                var obj = await _agentService.PostDaySchedule(daySchedule);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GettingLastPostedPackage")]
        public async Task<ActionResult<Package>> GetAllPackage()
        {
            try
            {
                var obj = await _agentService.GetAllPackage();
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
