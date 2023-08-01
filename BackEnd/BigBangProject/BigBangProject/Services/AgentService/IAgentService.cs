using BigBangProject.Model;

namespace BigBangProject.Services.AgentService
{
    public interface IAgentService
    {
        Task<int?> GetIdByLocationName(string locationName);
        Task<List<SightSeeing>> GetSpotbyLocationId(int locationId);
        Task<List<Hotel>> GetHotelbySpotId(int spotId);
        Task<List<Package>> PostPackage(Package package);
        Task<List<DaySchedule>> PostDaySchedule(DaySchedule schedule);
    }
}
