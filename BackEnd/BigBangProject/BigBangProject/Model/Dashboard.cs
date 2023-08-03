using BigBangProject.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xunit.Sdk;

namespace BigBangProject.Model
{
    public class Dashboard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Place Name is required.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = string.Empty;
        public string? ImageName { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Hotel image is required.")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif" }, ErrorMessage = "Invalid file format. Only .jpg, .jpeg, .png, and .gif are allowed.")]
        [MaxFileSize(10 * 1024 * 1024, ErrorMessage = "Maximum file size allowed is 10MB.")]
        public IFormFile? HotelImage { get; set; }

        [NotMapped]
        public string? ImageSrc { get; set; }
    }
}
