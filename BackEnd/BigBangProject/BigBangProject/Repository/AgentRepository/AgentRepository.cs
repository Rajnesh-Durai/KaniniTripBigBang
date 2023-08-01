using BigBangProject.DataContext;
using BigBangProject.GlobalException;
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
            if(locationName==null)
            {
                throw new ArgumentNullException(CustomException.ExceptionMessages["CantEmpty"]);
            }
            var idNo = await _dbContext.Locations.FirstOrDefaultAsync(s => s.LocationName == locationName);
            if (idNo == null)
            {
                throw new Exception(CustomException.ExceptionMessages["NoLocate"]);
            }
            return idNo?.Id;
        }
        public async Task<List<SightSeeing>> GetSpotbyLocationId(int? locationId)
        {
            if(locationId==null)
            {
                throw new Exception(CustomException.ExceptionMessages["NoId"]);
            }
            var list=await _dbContext.SightSeeings.Where(s=>s.LocationId == locationId).ToListAsync();
            if (list == null)
            {
                throw new Exception(CustomException.ExceptionMessages["NoSpot"]);
            }
            return list;
        }
        public async Task<List<Hotel>> GetHotelbySpotId(int? spotId)
        {
            if(spotId==null)
            {
                throw new Exception(CustomException.ExceptionMessages["NoId"]);
            }
            var list = await _dbContext.Hotels.Where(s => s.SightSeeingId == spotId).ToListAsync();
            if (list == null)
            {
                throw new Exception(CustomException.ExceptionMessages["NoSpot"]);
            }
            return list;
        }
        public async Task<List<Package>> PostPackage(Package package)
        {
            if(package==null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            await _dbContext.Packages.AddAsync(package);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Packages.ToListAsync();
        }
        public async Task<List<DaySchedule>> PostDaySchedule(DaySchedule schedule)
        {
            if (schedule == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            await _dbContext.DaySchedules.AddAsync(schedule);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.DaySchedules.ToListAsync();
        }
    }
}
