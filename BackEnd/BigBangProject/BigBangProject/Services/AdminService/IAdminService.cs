using BigBangProject.Model;
using Microsoft.AspNetCore.Mvc;

namespace BigBangProject.Services.AdminService
{
    public interface IAdminService
    {
        Task<List<AgentRequest>> GetRequest();
        Task<List<AgentRequest>> PostRequest(AgentRequest agentRequest);
    }
}
