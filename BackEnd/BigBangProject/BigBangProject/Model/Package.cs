using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigBangProject.Model
{
    public class Package
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public string? ImageName { get; set; }
        [NotMapped]
        public IFormFile? PackageImage { get; set; }
        [NotMapped]
        public string? ImageSrc { get; set; }
        public int? NumberOfDays { get; set; }
        public int? PricePerPerson { get; set; }
        public string? PackageDescription { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
        public ICollection<DaySchedule>? DaySchedules { get; set; }


    }
}
