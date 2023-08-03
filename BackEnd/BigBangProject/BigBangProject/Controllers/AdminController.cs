using BigBangProject.DataContext;
using BigBangProject.Model;
using BigBangProject.Model.DTO;
using BigBangProject.Services.AdminService;
using BigBangProject.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace BigBangProject.Controllers
{
    [Route("Admin Side")]
    [ApiController]
    public class AdminController:ControllerBase
    {
        private readonly IAdminService _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly DBContext _dbContext;


        public AdminController(IAdminService context,IWebHostEnvironment hostEnvironment, DBContext dbContext)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _dbContext = dbContext;
        }

        [HttpGet("GetAllRequest")]
        public async Task<ActionResult<List<User>>> GetRequest()
        {
            try
            {
                var item = await _context.GetRequest();
                return Ok(item);
            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut("AgentAccepetance")]
        public async Task<ActionResult<List<User>>> PutRequest(int? userId, User user)
        {
            try
            {
                var item = await _context.PutRequest(userId,user);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("RejectAgentAccepetance")]
        public async Task<ActionResult<List<User>>> DeleteRequest(int? userId)
        {
            try
            {
                var item = await _context.DeleteRequest( userId);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("UploadImage")]
        public async Task<ActionResult<Dashboard>> PostDashboardImage([FromForm] Dashboard dashboard)
        {
            try
            {
                var createdHotel = await _context.PostDashboardImage(dashboard);
                return Ok(createdHotel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}

