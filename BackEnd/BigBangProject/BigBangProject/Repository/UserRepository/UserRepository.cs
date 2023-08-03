using BigBangProject.DataContext;
using BigBangProject.GlobalException;
using BigBangProject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace BigBangProject.Repository.UserRepository
{
    public class UserRepository:IUserRepository
    {
        private readonly DBContext _dbContext;
        private readonly IWebHostEnvironment _hostEnvironment;
        public UserRepository(DBContext dbContext, IWebHostEnvironment hostEnvironment)
        {
            _dbContext = dbContext;
            _hostEnvironment = hostEnvironment;
        }
        public async Task<List<Location>> GetLocation()
        {
            var item=await _dbContext.Locations.ToListAsync();
            if (item == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return item;
        }
        public async Task<Location> PostLocation([FromForm] Location location)
        {
            if (location == null)
            {
                throw new ArgumentException("Invalid file");
            }

            location.ImageName = await SaveImage(location.LocationImage);
            _dbContext.Locations.Add(location);
            await _dbContext.SaveChangesAsync();
            return location;
        }
        public async Task<List<Package>> GetAllPackage()
        {
            var total=await _dbContext.Packages.ToListAsync();
            if (total == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return total;
        }
        public async Task<List<Package>> GetPackage(int locationId)
        {
            var total = await _dbContext.Packages.Where(s=>s.LocationId==locationId).ToListAsync();
            if (total == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return total;
        }
        public async Task<Package> PostPackage([FromForm] Package package)
        {
            if (package == null)
            {
                throw new ArgumentException("Invalid file");
            }

            package.ImageName = await SaveImage(package.PackageImage);
            _dbContext.Packages.Add(package);
            await _dbContext.SaveChangesAsync();
            return package;
        }
        public async Task<List<Hotel>> GetAllHotels()
        {
            var item = await _dbContext.Hotels.ToListAsync();
            if (item == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return item;
        }
        public async Task<Hotel> PostHotel([FromForm] Hotel hotel)
        {
            if (hotel == null)
            {
                throw new ArgumentException("Invalid file");
            }

            hotel.HotelImageName = await SaveImage(hotel.HotelImage);
            _dbContext.Hotels.Add(hotel);
            await _dbContext.SaveChangesAsync();
            return hotel;
        }
        public async Task<List<SightSeeing>> GetAllSightSeeing()
        {
            var item = await _dbContext.SightSeeings.ToListAsync();
            if (item == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return item;
        }
        public async Task<SightSeeing> PostSightSeeing([FromForm] SightSeeing spot)
        {
            if (spot == null)
            {
                throw new ArgumentException("Invalid file");
            }

            spot.ImageName = await SaveImage(spot.SpotImage);
            _dbContext.SightSeeings.Add(spot);
            await _dbContext.SaveChangesAsync();
            return spot;
        }
        public async Task<List<DaySchedule>> GetAllDaySchedule()
        {
            var daySchedules = await _dbContext.DaySchedules.ToListAsync();
            if (daySchedules == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return daySchedules;
        }
        public async Task<List<DaySchedule>> GetDayScheduleForPackage(int packageId)
        {
            var list=await _dbContext.DaySchedules.Where(s=>s.PackageId == packageId).ToListAsync();
            if (list == null)
            {
                throw new Exception(CustomException.ExceptionMessages["NoId"]);
            }
            return list;
        }
        public async Task<List<Booking>> BookPackage(Booking booking)
        {
            if (booking == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            await _dbContext.Bookings.AddAsync(booking);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Bookings.ToListAsync();
        }
        public async Task<string?> GetEmailById(int Id)
        {
            var email = await _dbContext.Users
                .Where(u => u.Id == Id)
                .Select(u => u.Email)
                .FirstOrDefaultAsync();
            if (email == null)
            {
                throw new Exception(CustomException.ExceptionMessages["NoId"]);
            }
            return email;
        }
        public async Task<List<Feedback>> PostFeedback(Feedback feedback)
        {
            if (feedback == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            await _dbContext.Feedbacks.AddAsync(feedback);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Feedbacks.ToListAsync();
        }

        public async Task<SightSeeing> GetSpotByName(string name)
        {
            var item= await _dbContext.SightSeeings.FirstOrDefaultAsync(s=>s.SpotAddress == name);
            if (item == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return item;
        }
        public async Task<Hotel> GetHotelByName(string name)
        {
            var item = await _dbContext.Hotels.FirstOrDefaultAsync(s => s.HotelName == name);
            if (item == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return item;
        }
        public async Task<Package> GetPackageById(int id)
        {
            var item = await _dbContext.Packages.FirstOrDefaultAsync(s => s.Id == id);
            if (item == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return item;
        }

        public async Task<SightSeeing> GetSightSeeingBySpotName(string spot)
        {
            var item = await _dbContext.SightSeeings.FirstOrDefaultAsync(s=>s.SpotName== spot);
            if (item == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return item;
        }
        public async Task<Hotel> GetHotelsBySightSeeingId(int locationId)
        {
            var item = await _dbContext.Hotels.FirstOrDefaultAsync(s => s.SightSeeingId == locationId);
            if (item == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return item;
        }
        public async Task<List<Dashboard>> GetAllDashboard()
        {
            var item =await _dbContext.Dashboards.ToListAsync();
            if (item == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return item;
        
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
