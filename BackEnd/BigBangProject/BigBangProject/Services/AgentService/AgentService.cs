using BigBangProject.Model;
using BigBangProject.Repository.AgentRepository;

namespace BigBangProject.Services.AgentService
{
    public class AgentService:IAgentService
    {
        private readonly IAgentRepository _agentRepository;
        public AgentService(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }
        public async Task<int?> GetIdByLocationName(string locationName)
        {
            var result= await _agentRepository.GetIdByLocationName(locationName);
            return result;
        }
        public async Task<List<SightSeeing>> GetSpotbyLocationId(int locationId)
        {
            var result= await _agentRepository.GetSpotbyLocationId(locationId); 
            return result;
        }
        public async Task<List<Hotel>> GetHotelbySpotId(int spotId)
        {
            var result = await _agentRepository.GetHotelbySpotId(spotId);
            return result;
        }
        public async Task<List<Package>> PostPackage(Package package)
        {
            var result= await _agentRepository.PostPackage(package);
            return result;
        }
        public async Task<List<DaySchedule>> PostDaySchedule(DaySchedule schedule)
        {
            var result= await _agentRepository.PostDaySchedule(schedule);
            return result;
        }
    }
}
