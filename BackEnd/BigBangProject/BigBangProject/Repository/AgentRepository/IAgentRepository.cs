using BigBangProject.Model;

namespace BigBangProject.Repository.AgentRepository
{
    public interface IAgentRepository
    {
        Task<int?> GetIdByLocationName(string locationName); 
        Task<List<SightSeeing>> GetSpotbyLocationId(int locationId);
        Task<List<Hotel>> GetHotelbySpotId(int spotId);
        Task<List<Package>> PostPackage(Package package);
        Task<List<DaySchedule>> PostDaySchedule(DaySchedule schedule);
    }
}
