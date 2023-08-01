using BigBangProject.Model;
using Microsoft.AspNetCore.Mvc;

namespace BigBangProject.Repository.UserRepository
{
    public interface IUserRepository
    {
        Task<List<Location>> GetLocation();
        Task<List<Package>> GetAllPackage();
        Task<List<Hotel>> GetAllHotels();
        Task<List<SightSeeing>> GetAllSightSeeing();
        Task<List<DaySchedule>> GetAllDaySchedule(int locationId);
        Task<List<DaySchedule>> GetDayScheduleForPackage (int packageId);
        Task<List<Booking>> BookPackage(Booking booking);
        Task<string?> GetEmailById(int Id);
        Task<List<Feedback>> PostFeedback(Feedback feedback);
        Task<SightSeeing> GetSpotByName(string name);
        Task<Hotel> GetHotelByName(string name);
        Task<Package> GetPackageById(int Id);
    }
}
