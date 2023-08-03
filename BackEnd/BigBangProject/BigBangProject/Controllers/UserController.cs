using BigBangProject.Model;
using BigBangProject.Model.DTO;
using BigBangProject.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace BigBangProject.Controllers
{
    [Route("UserSide")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly IUserService _context;

        public UserController(IUserService context)
        {
            _context = context;
        }

        [HttpGet("DisplayingAllLocations")]
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
        [HttpGet("GetPackage")]
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

        [HttpGet("GetParticularPackageDetails")]
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

        [HttpPost("BookingAPackage")]
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
        [HttpGet("GetEmailById")]
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
        [HttpPost("PostingFeedback")]
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
        [HttpPost("PostPackage")]
        public async Task<ActionResult<Package>> PostPackage([FromForm] Package package)
        {
            try
            {
                var createdHotel = await _context.PostPackage(package);
                return Ok(createdHotel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("PostLocation")]
        public async Task<ActionResult<Location>> PostLocation([FromForm] Location location)
        {
            try
            {
                var createdHotel = await _context.PostLocation(location);
                return Ok(createdHotel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("PostHotel")]
        public async Task<ActionResult<Hotel>> PostHotel([FromForm] Hotel hotel)
        {
            try
            {
                var createdHotel = await _context.PostHotel(hotel);
                return Ok(createdHotel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("PostSpot")]
        public async Task<ActionResult<SightSeeing>> PostSightSeeing([FromForm] SightSeeing spot)
        {
            try
            {
                var createdHotel = await _context.PostSightSeeing(spot);
                return Ok(createdHotel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("GetDashboardImage")]
        public async Task<ActionResult<List<Dashboard>>> GetAllDashboard()
        {
            try
            {
                var createdHotel = await _context.GetAllDashboard();
                return Ok(createdHotel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
