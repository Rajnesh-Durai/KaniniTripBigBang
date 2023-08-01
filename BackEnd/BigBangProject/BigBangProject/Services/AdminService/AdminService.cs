using BigBangProject.Model;
using BigBangProject.Repository.AdminRepository;

namespace BigBangProject.Services.AdminService
{
    public class AdminService:IAdminService
    {
        private readonly IAdminRepository _adminRepo;
        public AdminService(IAdminRepository adminRepo)
        {
            _adminRepo = adminRepo;
        }
        public async Task<List<AgentRequest>> GetRequest()
        {
            var item = await _adminRepo.GetRequest();
            return item;
        }
        public async Task<List<AgentRequest>> PostRequest(AgentRequest agentRequest)
        {
            var item = await _adminRepo.PostRequest(agentRequest);
            return item;
        }
    }
}
