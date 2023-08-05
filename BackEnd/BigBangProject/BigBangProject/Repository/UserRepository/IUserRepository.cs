using BigBangProject.Model;
using Microsoft.AspNetCore.Mvc;

namespace BigBangProject.Repository.UserRepository
{
    public interface IUserRepository
    {
        Task<List<Location>> GetLocation();
        Task<Location> PostLocation([FromForm] Location location);
        Task<List<Package>> GetAllPackage();
        Task<List<Package>> GetPackage(int locationId);
        Task<Package> PostPackage([FromForm] Package package);
        Task<List<Hotel>> GetAllHotels();
        Task<Hotel> PostHotel([FromForm] Hotel hotel);
        Task<List<SightSeeing>> GetAllSightSeeing();
        Task<SightSeeing> PostSightSeeing([FromForm] SightSeeing spot);
        Task<List<DaySchedule>> GetAllDaySchedule();
        Task<List<DaySchedule>> GetDayScheduleForPackage (int packageId);
        Task<List<Booking>> BookPackage(Booking booking);
        Task<string?> GetEmailById(int Id);
        Task<List<Feedback>> PostFeedback(Feedback feedback);
        Task<SightSeeing> GetSpotByName(string name);
        Task<Hotel> GetHotelByName(string name);
        Task<Package> GetPackageById(int Id);
        Task<SightSeeing> GetSightSeeingBySpotName(string spot);
        Task<Hotel> GetHotelsBySightSeeingId(int sightSeeingId);
        Task<List<Dashboard>> GetAllDashboard();
        Task<List<User>> GetAllUsers();
    }
}
