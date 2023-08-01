using BigBangProject.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace BigBangProject.Model
{
    public class Package
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("User")]
        [Required(ErrorMessage = "User Id is required.")]
        public int UserId { get; set; }

        [ForeignKey("Location")]
        [Required(ErrorMessage = "Location Id is required.")]
        public int LocationId { get; set; }

        [Required(ErrorMessage = "Package name is required.")]
        public string? PackageName { get; set; }

        public string? ImageName { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Package image is required.")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif" }, ErrorMessage = "Invalid file format. Only .jpg, .jpeg, .png, and .gif are allowed.")]
        [MaxFileSize(10 * 1024 * 1024, ErrorMessage = "Maximum file size allowed is 10MB.")]
        public IFormFile? PackageImage { get; set; }

        [NotMapped]
        public string? ImageSrc { get; set; }

        [Required(ErrorMessage = "Number of days is required.")]
        public int? NumberOfDays { get; set; }

        [Required(ErrorMessage = "Price per person is required.")]
        public int? PricePerPerson { get; set; }

        [Required(ErrorMessage = "Iternary is required.")]
        public string? Iternary { get; set; }

        [Range(1, 200, ErrorMessage = "Person limit must be greater than or equal to 1.")]
        public int? PersonLimit { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
        public ICollection<DaySchedule>? DaySchedules { get; set; }

    }
}
