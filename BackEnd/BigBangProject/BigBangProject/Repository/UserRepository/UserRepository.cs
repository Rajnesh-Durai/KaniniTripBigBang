using BigBangProject.DataContext;
using BigBangProject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return item;
        }
        public async Task<List<Package>> GetAllPackage()
        {
            var total=await _dbContext.Packages.ToListAsync();
            return total;
        }
        public async Task<List<Hotel>> GetAllHotels()
        {
            var item = await _dbContext.Hotels.ToListAsync();
            return item;
        }

        public async Task<List<SightSeeing>> GetAllSightSeeing()
        {
            var item = await _dbContext.SightSeeings.ToListAsync();
            return item;
        }
        public async Task<List<DaySchedule>> GetAllDaySchedule(int locationId)
        {
            var daySchedules = await (from pack in _dbContext.Packages
                                      join day in _dbContext.DaySchedules on pack.Id equals day.PackageId
                                      where pack.LocationId == locationId
                                      select day
                ).ToListAsync();

            return daySchedules;
        }
        public async Task<List<DaySchedule>> GetDayScheduleForPackage(int packageId)
        {
            var list=await _dbContext.DaySchedules.Where(s=>s.PackageId == packageId).ToListAsync();
            return list;
        }
        public async Task<List<Booking>> BookPackage(Booking booking)
        {
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

            return email;
        }
        public async Task<List<Feedback>> PostFeedback(Feedback feedback)
        {
            await _dbContext.Feedbacks.AddAsync(feedback);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Feedbacks.ToListAsync();
        }

    }
}
