using BigBangProject.GlobalException;
using BigBangProject.Model;
using BigBangProject.Repository.AdminRepository;
using Microsoft.AspNetCore.Mvc;

namespace BigBangProject.Services.AdminService
{
    public class AdminService:IAdminService
    {
        private readonly IAdminRepository _adminRepo;
        public AdminService(IAdminRepository adminRepo)
        {
            _adminRepo = adminRepo;
        }
        public async Task<List<User>> GetRequest()
        {
            var item = await _adminRepo.GetRequest();
            if (item == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return item;
        }
        public async Task<List<User>> PutRequest(int? userId, User user)
        {
            if (userId == null || user==null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            var item= await _adminRepo.PutRequest(userId, user);
            if (item == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return item;
        }
        public async Task<List<User>> DeleteRequest(int? userId)
        {
            if (userId == null )
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            var result= await _adminRepo.DeleteRequest(userId);
            if (result == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return result;
        }
        public async Task<Dashboard> PostDashboardImage([FromForm] Dashboard dashboard)
        {
            if (dashboard == null)
            {
                throw new Exception("Invalid file");
            }
            var item = await _adminRepo.PostDashboardImage(dashboard);
            if (item == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return item;
        }
    }
}
