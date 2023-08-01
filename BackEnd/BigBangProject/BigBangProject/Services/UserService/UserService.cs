using BigBangProject.GlobalException;
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
            if (items == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
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
            if (items == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return items;
        }
        public async Task<List<ScheduleDTO>> GetDayScheduleForPackage(int packageId)
        {
            var daySchedules = await _userRepository.GetDayScheduleForPackage(packageId);
            var package = await _userRepository.GetPackageById(packageId);

            var dayWiseSchedules = new List<ScheduleDTO>();

            for (int dayNo = 1; dayNo <= package.NumberOfDays; dayNo++)
            {
                var daySchedule = daySchedules.FirstOrDefault(ds => ds.Daywise == dayNo);
                if (daySchedule == null)
                {
                    throw new Exception("daySchedule is null");
                }
                else
                {
                    var spot = await _userRepository.GetSpotByName(daySchedule.SpotName ?? "");
                    var hotel = await _userRepository.GetHotelByName(daySchedule.HotelName ?? "");

                    var dayWiseSchedule = new ScheduleDTO
                    {
                        PackageId =daySchedule.PackageId,
                        Id = daySchedule.Id,
                        Day = dayNo,
                        SpotName = daySchedule.SpotName,
                        SpotImage = spot?.ImageName,
                        SpotAddress = spot?.SpotAddress,
                        SpotDuration = spot?.DurationPerHour ?? 0,
                        HotelName = daySchedule.HotelName,
                        HotelImage = hotel?.HotelImageName,
                        Rating = hotel?.Ratings ?? 0,
                        VehicleName = daySchedule.VehicleName,
                        MealsImage = hotel?.MealsImageName,
                        MealsName =hotel?.FoodDescription,
                        BedType=hotel?.BedType,
                        HotelFeatures = hotel?.HotelFeatures
                    };

                    dayWiseSchedules.Add(dayWiseSchedule);
                }
            }

            return dayWiseSchedules;

        }

        public async Task<List<Booking>> BookPackage(Booking booking)
        {
            var itemlist = await _userRepository.BookPackage(booking);
            if (itemlist == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return itemlist;
        }
        public async Task<string?> GetEmailById(int Id)
        {
            var item = await _userRepository.GetEmailById(Id);
            if (item == null)
            {
                throw new ArgumentNullException(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return item;
        }
        public async Task<List<Feedback>> PostFeedback(Feedback feedback)
        {
            var item= await _userRepository.PostFeedback(feedback);
            if (item == null)
            {
                throw new ArgumentNullException(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return item;
        }
    }
}
