using BigBangProject.GlobalException;
using BigBangProject.Model;
using BigBangProject.Model.DTO;
using BigBangProject.Repository.UserRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace BigBangProject.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        private readonly IWebHostEnvironment _hostEnvironment;
        public UserService(IUserRepository userRepository, IWebHostEnvironment hostEnvironment)
        {
            _userRepository = userRepository;
            _hostEnvironment = hostEnvironment;
        }
        public async Task<List<LocationDTO>> GetLocation()
        {
            var locations = await _userRepository.GetLocation();
            var packages = await _userRepository.GetAllPackage();

            var items = (from locate in locations
                         join pack in packages on locate.Id equals pack.LocationId into locationPackages
                         select new LocationDTO()
                         {
                             ImageName = ConvertToBase64(locate.ImageName),
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
        private string ConvertToBase64(string imageName)
        {
            var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
            var filePath = Path.Combine(uploadsFolder, imageName);

            var imageBytes = System.IO.File.ReadAllBytes(filePath);
            return Convert.ToBase64String(imageBytes);
        }
        public async Task<List<PackageDTO>?> GetAllPackage(int locationId)
        {
            var packages = await _userRepository.GetPackage(locationId);
            var day = await _userRepository.GetAllDaySchedule();

            var items = (from pack in packages
                         join schedule in day on pack.Id equals schedule.PackageId
                         where pack.Id == schedule.PackageId
                         select new PackageDTO()
                         {
                             PackageId = pack.Id,
                             PackageName = pack.PackageName,
                             Iternary = pack.Iternary,
                             HotelName = schedule.HotelName, // Include HotelName in PackageDTO
                             SpotName = schedule.SpotName,   // Include SpotName in PackageDTO
                             VehicleName = schedule.VehicleName, // Include VehicleName in PackageDTO
                             PricePerPerson = pack.PricePerPerson,
                             TotalDays=pack.NumberOfDays,
                             ImageName= ConvertToBase64(pack.ImageName),
                         }
               ).ToList();

            if (items == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }

            // Group the items based on PackageId and calculate NoOfHotel, NoOfSpot, and NoOfVehicle
            var groupedItems = items.GroupBy(item => item.PackageId)
                                    .Select(group => new PackageDTO()
                                    {
                                        PackageId = group.Key,
                                        PackageName = group.First().PackageName,
                                        Iternary = group.First().Iternary,
                                        NoOfHotel = group.Select(item => item.HotelName).Distinct().Count(),
                                        NoOfSpot = group.Select(item => item.SpotName).Distinct().Count(),
                                        NoOfVehicle = group.Select(item => item.VehicleName).Count(),
                                        PricePerPerson = group.First().PricePerPerson,
                                        TotalDays=group.First().TotalDays,
                                        ImageName = group.First().ImageName
                                    }).ToList();

            return groupedItems;
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
                    var spot = await _userRepository.GetSpotByName(daySchedule.SpotName);
                    var hotel = await _userRepository.GetHotelByName(daySchedule.HotelName);

                    var dayWiseSchedule = new ScheduleDTO
                    {
                        PackageId =daySchedule.PackageId,
                        Id = daySchedule.Id,
                        Day = dayNo,
                        SpotName = daySchedule.SpotName,
                        SpotImage = ConvertToBase64( spot?.ImageName),
                        SpotAddress = spot?.SpotAddress,
                        SpotDuration = spot?.DurationPerHour ?? 0,
                        HotelName = daySchedule.HotelName,
                        HotelImage = ConvertToBase64(hotel?.HotelImageName),
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

        public async Task<Package> PostPackage([FromForm] Package package)
        {
            if (package == null)
            {
                throw new Exception("Invalid file");
            }
            var item = await _userRepository.PostPackage(package);
            if (item == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return item;
        }
        public async Task<Location> PostLocation([FromForm] Location location)
        {
            if (location == null)
            {
                throw new Exception("Invalid file");
            }
            var item = await _userRepository.PostLocation(location);
            if (item == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return item;
        }
        public async Task<Hotel> PostHotel([FromForm] Hotel hotel)
        {
            if (hotel == null)
            {
                throw new Exception("Invalid file");
            }
            var item = await _userRepository.PostHotel(hotel);
            if (item == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return item;
        }
        public async Task<SightSeeing> PostSightSeeing([FromForm] SightSeeing spot)
        {
            if (spot == null)
            {
                throw new Exception("Invalid file");
            }
            var item = await _userRepository.PostSightSeeing(spot);
            if (item == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return item;
        }
        public async Task<List<Dashboard>> GetAllDashboard()
        {
            var get = await _userRepository.GetAllDashboard();
            var imageList = new List<Dashboard>();
            foreach (var image in get)
            {
                var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                var filePath = Path.Combine(uploadsFolder, image.ImageName);

                var imageBytes = System.IO.File.ReadAllBytes(filePath);
                var tourData = new Dashboard
                {
                    Id = image.Id,
                    Name = image.Name,
                    Description = image.Description,
                    ImageSrc = image.ImageSrc,
                    ImageName = Convert.ToBase64String(imageBytes)
                };
                imageList.Add(tourData);
            }
            return imageList;
        }
        public async Task<User> GetAdmin()
        {
            var item= await _userRepository.GetAllUsers();
            // Get the first User with role "admin" or null if there is no such user
            var adminUser = item.FirstOrDefault(user => user.Role == "Admin");
            if (adminUser == null)
            {
                throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            return adminUser;
        }
    }
}
