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
            try
            {
                var obj = await _context.GetLocation();
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Get Package")]
        public async Task<ActionResult<List<PackageDTO>?>> GetAllPackage(int locationId)
        {
            try
            {
                var obj = await _context.GetAllPackage(locationId);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get Particular Package Details")]
        public async Task<ActionResult<List<ScheduleDTO>>> GetDayScheduleForPackage(int packageId)
        {
            try
            {
                var obj = await _context.GetDayScheduleForPackage(packageId);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Booking a Package")]
        public async Task<ActionResult<List<Booking>>> BookPackage(Booking booking)
        {
            try
            {
                var obj = await _context.BookPackage(booking);
                return Ok(obj);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Get Email By Id")]
        public async Task<ActionResult<string>?> GetEmailById(int Id)
        {
            try
            {
                var obj = await _context.GetEmailById(Id);
                return Ok(obj);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Posting Feedback")]
        public async Task<ActionResult<List<Feedback>>> PostFeedback(Feedback feedback)
        {
            try
            {
                var obj = await _context.PostFeedback(feedback);
                return Ok(obj);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
