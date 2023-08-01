using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace BigBangProject.Model.DTO
{
    public class ScheduleDTO
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public int LocationId { get; set; }
        public int Day { get; set; }
        public string? SpotImage { get; set; }
        public string? SpotName { get; set; }
        public string? VehicleName { get; set; }
        public string? MealsImage { get; set; }
        public string? MealsName { get; set; }
        public string? HotelImage { get; set; }
        public string? HotelName { get; set; }
        public string? PackageImage { get; set; }
        public int Rating { get; set; }
        public int SpotDuration { get; set; }
        public string? SpotAddress { get; set; }
        public string? BedType { get; set; }
        public string? HotelFeatures { get; set; }
    }
}
