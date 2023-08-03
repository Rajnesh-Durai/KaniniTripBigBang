using BigBangProject.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xunit.Sdk;

namespace BigBangProject.Model
{
    public class SightSeeing
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Location")]
        [Required(ErrorMessage = "Location Id is required.")]
        public int LocationId { get; set; }

        [Required(ErrorMessage = "Spot name is required.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Only alphabets are allowed in the Name.")]
        [StringLength(30, ErrorMessage = "SpotName cannot exceed 30 characters.")]
        public string? SpotName { get; set; }

        public string? ImageName { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Spot image is required.")]
        [DataType(DataType.Upload)]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif" }, ErrorMessage = "Invalid file format. Only .jpg, .jpeg, .png, and .gif are allowed.")]
        [MaxFileSize(10 * 1024 * 1024, ErrorMessage = "Maximum file size allowed is 10MB.")]
        public IFormFile? SpotImage { get; set; }

        [NotMapped]
        public string? ImageSrc { get; set; }

        [Required(ErrorMessage = "Duration per hour is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Duration per hour must be a positive integer.")]
        public int? DurationPerHour { get; set; }
        [Required(ErrorMessage = "Spot Address is required.")]
        [StringLength(200, ErrorMessage = "Spot Address cannot exceed 200 characters.")]
        public string? SpotAddress { get; set; }

        public ICollection<Hotel>? Hotels { get; set; }

    }
}
