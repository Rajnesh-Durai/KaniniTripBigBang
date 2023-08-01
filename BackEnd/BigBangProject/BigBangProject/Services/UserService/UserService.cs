using BigBangProject.Model;
using BigBangProject.Model.DTO;
using BigBangProject.Repository.UserRepository;
using Microsoft.AspNetCore.Mvc;

namespace BigBangProject.Services.UserService
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<LocationDTO>> GetLocation()
        {
            var locations = await _userRepository.GetLocation();
            var packages = await _userRepository.GetAllPackage();

            var items = (from locate in locations
                         join pack in packages on locate.Id equals pack.LocationId into locationPackages
                         select new LocationDTO()
                         {
                             LocationId = locate.Id,
                             LocationName = locate.LocationName,
                             PackStarts = locationPackages.Min(p => p.PricePerPerson)
                         }
                        ).ToList();

            return items;
        }
        public async Task<List<PackageDTO>?> GetAllPackage(int locationId)
        {
            var package= await _userRepository.GetAllPackage();
            var day = await _userRepository.GetAllDaySchedule(locationId);

            var items = (from pack in package
                         join schedule in day on pack.Id equals schedule.PackageId
                         where pack.LocationId == locationId
                         select new PackageDTO()
                         {
                             PackageId=pack.Id,
                             PackageName = pack.PackageName,
                             Iternary= pack.Iternary,
                             NoOfHotel = day.Select(d => d.HotelName).Distinct().Count(),
                             NoOfSpot = day.Select(d => d.SpotName).Distinct().Count(),
                             NoOfVehicle = day.Select(d => d.VehicleName).Distinct().Count(),
                             PricePerPerson =pack.PricePerPerson
                         }
                        ).ToList();
            return items;
        }
        public async Task<List<ScheduleDTO>> GetDayScheduleForPackage(int packageId)
        {
            var item = await _userRepository.GetDayScheduleForPackage(packageId);
            var package = await _userRepository.GetAllPackage();
            var locate = await _userRepository.GetLocation();
            var hotel = await _userRepository.GetAllHotels();
            var spot = await _userRepository.GetAllSightSeeing();
            var itemlist = (from pack in package
                            join loc in locate on pack.LocationId equals loc.Id
                            join spt in spot on loc.Id equals spt.LocationId
                            join hot in hotel on spt.Id equals hot.SightSeeingId
                            join sched in item on pack.Id equals sched.PackageId
                            where pack.Id == packageId && sched.HotelName==hot.HotelName && sched.SpotName==spt.SpotName
                            select new ScheduleDTO()
                            {
                                PackageId=pack.Id,
                                LocationId=loc.Id,
                                HotelImage=hot.HotelImageName,
                                HotelName=sched.HotelName,
                                SpotImage=spt.ImageName,
                                SpotName=sched.SpotName,
                                VehicleName=sched.VehicleName,
                                PackageImage=pack.ImageName,
                                Day=sched.Daywise
                            }
                ).ToList();
            return itemlist;
        }

        public async Task<List<Booking>> BookPackage(Booking booking)
        {
            var itemlist = await _userRepository.BookPackage(booking);
            return itemlist;
        }
        public async Task<string?> GetEmailById(int Id)
        {
            var item = await _userRepository.GetEmailById(Id);
            return item;
        }
        public async Task<List<Feedback>> PostFeedback(Feedback feedback)
        {
            var item= await _userRepository.PostFeedback(feedback);
            return item;
        }
    }
}
