using BigBangProject.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace BigBangProject.Model
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Location name is required.")]
        [StringLength(100, ErrorMessage = "Location name cannot exceed 100 characters.")]
        public string LocationName { get; set; } = string.Empty;

        public string? ImageName { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Location image is required.")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif" }, ErrorMessage = "Invalid file format. Only .jpg, .jpeg, .png, and .gif are allowed.")]
        [MaxFileSize(10 * 1024 * 1024, ErrorMessage = "Maximum file size allowed is 10MB.")]
        public IFormFile? LocationImage { get; set; }

        [NotMapped]
        public string? ImageSrc { get; set; }
        public ICollection<Package>? Packages { get; set; }
        public ICollection<SightSeeing>? SightSeeings { get; set; }


    }
}
