using BigBangProject.Model;
using BigBangProject.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BigBangProject.Repository.AdminRepository
{
    public interface IAdminRepository
    {
        Task<List<User>> GetRequest();
        Task<List<User>> PutRequest(int? userId, User user);
        Task<List<User>> DeleteRequest(int? userId);
        Task<Dashboard> PostDashboardImage([FromForm] Dashboard dashboard);
    }
}
