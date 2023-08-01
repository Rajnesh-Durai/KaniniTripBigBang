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
        [HttpGet("Displaying All Request")]
        public async Task<ActionResult<List<AgentRequest>>> GetRequest()
        {
            try
            {
                var obj = await _context.GetRequest();
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Posting A Request")]
        public async Task<ActionResult<List<AgentRequest>>> PostRequest(AgentRequest agentRequest)
        {

            try
            {
                var obj = await _context.PostRequest(agentRequest);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("Upload Image")]
        public async Task<ActionResult<Dashboard>> PostDashboardImage([FromForm] Dashboard dashboard)
        {
            dashboard.ImageName = await SaveImage(dashboard.HotelImage);
            _dbContext.Dashboards.Add(dashboard);
            await _dbContext.SaveChangesAsync();
            return StatusCode(201);
        }

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot/Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }

        [NonAction]
        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }

    }
}

