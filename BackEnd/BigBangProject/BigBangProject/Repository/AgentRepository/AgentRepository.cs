using BigBangProject.DataContext;
using BigBangProject.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BigBangProject.Repository.AgentRepository
{
    public class AgentRepository:IAgentRepository
    {
        private readonly DBContext _dbContext;
        public AgentRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int?> GetIdByLocationName(string locationName)
        {
            var idNo = await _dbContext.Locations.FirstOrDefaultAsync(s => s.LocationName == locationName);
            return idNo?.Id;
        }
        public async Task<List<SightSeeing>> GetSpotbyLocationId(int locationId)
        {
            var list=await _dbContext.SightSeeings.Where(s=>s.LocationId == locationId).ToListAsync();
            return list;
        }
        public async Task<List<Hotel>> GetHotelbySpotId(int spotId)
        {
            var list = await _dbContext.Hotels.Where(s => s.SightSeeingId == spotId).ToListAsync();
            return list;
        }
        public async Task<List<Package>> PostPackage(Package package)
        {
            await _dbContext.Packages.AddAsync(package);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Packages.ToListAsync();
        }
        public async Task<List<DaySchedule>> PostDaySchedule(DaySchedule schedule)
        {
            await _dbContext.DaySchedules.AddAsync(schedule);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.DaySchedules.ToListAsync();
        }
    }
}
