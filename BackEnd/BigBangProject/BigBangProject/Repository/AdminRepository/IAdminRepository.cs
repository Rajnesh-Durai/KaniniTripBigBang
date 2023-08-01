using BigBangProject.Model;
using BigBangProject.Model.DTO;

namespace BigBangProject.Repository.AdminRepository
{
    public interface IAdminRepository
    {
        Task<List<AgentRequest>> GetRequest();
        Task<List<AgentRequest>> PostRequest(AgentRequest agentRequest);
    }
}
