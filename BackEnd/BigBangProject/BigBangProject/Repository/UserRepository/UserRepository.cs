using BigBangProject.DataContext;
using BigBangProject.GlobalException;
using BigBangProject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BigBangProject.Repository.UserRepository
{
    public class UserRepository:IUserRepository
    {
        private readonly DBContext _dbContext;
        public UserRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
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
        public async Task<List<Package>> GetAllPackage()
        {
            var total=await _dbContext.Packages.ToListAsync();
            if (item == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return total;
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

        public async Task<List<SightSeeing>> GetAllSightSeeing()
        {
            var item = await _dbContext.SightSeeings.ToListAsync();
            if (item == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return item;
        }
        public async Task<List<DaySchedule>> GetAllDaySchedule(int locationId)
        {
            var daySchedules = await (from pack in _dbContext.Packages
                                      join day in _dbContext.DaySchedules on pack.Id equals day.PackageId
                                      where pack.LocationId == locationId
                                      select day
                ).ToListAsync();
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
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
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
            var item= await _dbContext.SightSeeings.FirstOrDefaultAsync(s=>s.SpotName == name);
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
    }
}
