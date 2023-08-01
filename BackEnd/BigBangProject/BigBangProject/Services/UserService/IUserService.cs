using BigBangProject.Model;
using BigBangProject.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BigBangProject.Services.UserService
{
    public interface IUserService
    {
        Task<List<LocationDTO>> GetLocation();
        Task<List<PackageDTO>?> GetAllPackage(int locationId);
        Task<List<ScheduleDTO>> GetDayScheduleForPackage(int packageId);
        Task<List<Booking>> BookPackage(Booking booking);
        Task<string?> GetEmailById(int Id);
        Task<List<Feedback>> PostFeedback(Feedback feedback);
    }
}
