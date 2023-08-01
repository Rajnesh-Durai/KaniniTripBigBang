using BigBangProject.Model;
using BigBangProject.Model.DTO;
using BigBangProject.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace BigBangProject.Controllers
{
    [Route("User Side")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly IUserService _context;

        public UserController(IUserService context)
        {
            _context = context;
        }

        [HttpGet("Displaying All Locations")]
        public async Task<ActionResult<List<LocationDTO>>> GetLocation()
        {
            var obj = await _context.GetLocation();
            if (obj == null)
            {
                return NotFound("Cannot Display the List of Tables");
            }
            return Ok(obj);
        }
        [HttpGet("Get Package")]
        public async Task<ActionResult<List<PackageDTO>?>> GetAllPackage(int locationId)
        {
            var obj = await _context.GetAllPackage(locationId);
            if (obj == null)
            {
                return NotFound("Cannot Display the List of Tables");
            }
            return Ok(obj);
        }

        [HttpGet("Get Particular Package Details")]
        public async Task<ActionResult<List<ScheduleDTO>>> GetDayScheduleForPackage(int packageId)
        {
            var obj = await _context.GetDayScheduleForPackage(packageId);
            if (obj == null)
            {
                return NotFound("Cannot Display the List of Tables");
            }
            return Ok(obj);
        }

        [HttpPost("Booking a Package")]
        public async Task<ActionResult<List<Booking>>> BookPackage(Booking booking)
        {
            var obj = await _context.BookPackage(booking);
            if (obj == null)
            {
                return NotFound("Cannot Display the List of Tables");
            }
            return Ok(obj);
        }
        [HttpGet("Get Email By Id")]
        public async Task<ActionResult<string>?> GetEmailById(int Id)
        {
            var obj = await _context.GetEmailById(Id);
            if (obj == null)
            {
                return NotFound("Cannot Display the List of Tables");
            }
            return Ok(obj);
        }
        [HttpPost("Posting Feedback")]
        public async Task<ActionResult<List<Feedback>>> PostFeedback(Feedback feedback)
        {
            var obj = await _context.PostFeedback(feedback);
            if (obj == null)
            {
                return NotFound("Cannot Display the List of Tables");
            }
            return Ok(obj);
        }
    }
}
