using BigBangProject.GlobalException;
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
            if (result == null)
            {
                throw new ArgumentNullException(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return result;
        }
        public async Task<List<SightSeeing>> GetSpotbyLocationId(int locationId)
        {
            var result= await _agentRepository.GetSpotbyLocationId(locationId);
            if (result == null)
            {
                throw new ArgumentNullException(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return result;
        }
        public async Task<List<Hotel>> GetHotelbySpotId(int spotId)
        {
            var result = await _agentRepository.GetHotelbySpotId(spotId);
            if (result == null)
            {
                throw new ArgumentNullException(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return result;
        }
        public async Task<List<Package>> PostPackage(Package package)
        {
            var result= await _agentRepository.PostPackage(package);
            if (result == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return result;
        }
        public async Task<List<DaySchedule>> PostDaySchedule(DaySchedule schedule)
        {
            var result= await _agentRepository.PostDaySchedule(schedule);
            if (result == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return result;
        }
    }
}
