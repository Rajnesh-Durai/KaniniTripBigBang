namespace BigBangProject.Model.DTO
{
    public class ScheduleDTO
    {
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
    }
}
