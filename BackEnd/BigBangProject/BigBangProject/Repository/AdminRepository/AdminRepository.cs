using BigBangProject.DataContext;
using BigBangProject.Model;
using BigBangProject.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace BigBangProject.Repository.AdminRepository
{
    public class AdminRepository:IAdminRepository
    {
        private readonly DBContext _dbContext;
        public AdminRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<AgentRequest>> GetRequest()
        { 
            var item = await _dbContext.AgentRequests.ToListAsync();
            return item;
        }
        public async Task<List<AgentRequest>> PostRequest(AgentRequest agentRequest)
        {
            await _dbContext.AgentRequests.AddAsync(agentRequest);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.AgentRequests.ToListAsync();
        }
    }
}
