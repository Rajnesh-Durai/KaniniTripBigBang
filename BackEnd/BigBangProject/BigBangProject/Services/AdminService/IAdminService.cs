using BigBangProject.Model;
using Microsoft.AspNetCore.Mvc;

namespace BigBangProject.Services.AdminService
{
    public interface IAdminService
    {
        Task<List<User>> GetRequest();
        Task<List<User>> PutRequest(int? userId, User user);
        Task<List<User>> DeleteRequest(int? userId);
        Task<Dashboard> PostDashboardImage([FromForm] Dashboard dashboard);
    }
}
