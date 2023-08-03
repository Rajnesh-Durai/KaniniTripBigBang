namespace BigBangProject.Model.DTO
{
    public class PackageDTO
    {
        public int PackageId { get; set; }
        public string? PackageName { get;set; }
        public int? PricePerPerson { get;set; }
        public string? Iternary { get;set;}
        public int? NoOfVehicle { get;set;}
        public int? NoOfSpot { get; set; }
        public int? NoOfHotel { get; set; }
        public string? HotelName { get; set; }
        public string? SpotName { get; set; }
        public string? VehicleName { get; set; }
        public int? TotalDays { get; set; }
    }
}
