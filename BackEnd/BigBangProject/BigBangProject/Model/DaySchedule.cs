using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xunit.Sdk;

namespace BigBangProject.Model
{
    public class DaySchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Package")]
        public int PackageId { get; set; }

        [Required(ErrorMessage = "Spot name is required.")]
        public string? SpotName { get; set; }

        [Required(ErrorMessage = "Hotel name is required.")]
        public string? HotelName { get; set; }

        [Required(ErrorMessage = "Vehicle name is required.")]
        public string VehicleName { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Daywise value must be a positive integer.")]
        public int Daywise { get; set; }

    }
}
