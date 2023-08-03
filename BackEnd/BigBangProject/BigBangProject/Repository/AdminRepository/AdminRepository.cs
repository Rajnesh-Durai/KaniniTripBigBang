using BigBangProject.DataContext;
using BigBangProject.GlobalException;
using BigBangProject.Model;
using BigBangProject.Model.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace BigBangProject.Repository.AdminRepository
{
    public class AdminRepository:IAdminRepository
    {
        private readonly DBContext _dbContext;
        private readonly IWebHostEnvironment _hostEnvironment;
        public AdminRepository(DBContext dbContext, IWebHostEnvironment hostEnvironment)
        {
            _dbContext = dbContext;
            _hostEnvironment = hostEnvironment;
        }
        public async Task<List<User>> GetRequest()
        { 
            var item = await _dbContext.Users.Where(s=>s.IsActive==false).ToListAsync();
            if(item == null)
            {
                throw new Exception(CustomException.ExceptionMessages["NoId"]);
            }
            return item;
        }
        public async Task<List<User>> PutRequest(int? userId, User user)
        {
            if (user == null || userId==null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            var item = await _dbContext.Users.FindAsync(userId);
            if (item == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            item.IsActive = true;
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<List<User>> DeleteRequest(int? userId)
        {
            if (userId == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            var item = await _dbContext.Users.FindAsync(userId);
            if (item == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            _dbContext.Users.Remove(item);
            await _dbContext.SaveChangesAsync();
            return _dbContext.Users.ToList();
        }
        public async Task<Dashboard> PostDashboardImage([FromForm] Dashboard dashboard)
        {
            if (dashboard == null)
            {
                throw new ArgumentException("Invalid file");
            }

            dashboard.ImageName = await SaveImage(dashboard.HotelImage);
            _dbContext.Dashboards.Add(dashboard);
            await _dbContext.SaveChangesAsync();
            return dashboard;
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
    }
}
