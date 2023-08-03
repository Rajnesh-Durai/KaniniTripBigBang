using BigBangProject.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace BigBangProject.Model
{
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("SightSeeing")]
        public int SightSeeingId { get; set; }

        [Required(ErrorMessage = "Hotel name is required.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Only alphabets are allowed in the Name.")]
        [StringLength(30, ErrorMessage = "PackageName cannot exceed 30 characters.")]
        public string? HotelName { get; set; }

        public string? HotelImageName { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Hotel image is required.")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif" }, ErrorMessage = "Invalid file format. Only .jpg, .jpeg, .png, and .gif are allowed.")]
        [MaxFileSize(10 * 1024 * 1024, ErrorMessage = "Maximum file size allowed is 10MB.")]
        public IFormFile? HotelImage { get; set; }

        [NotMapped]
        public string? HotelImageSrc { get; set; }

        [Range(1, 5, ErrorMessage = "Ratings must be between 1 and 5.")]
        public int Ratings { get; set; }


        [StringLength(100, ErrorMessage = "Comments cannot exceed 100 characters.")]
        public string? BedType { get; set; }


        [StringLength(100, ErrorMessage = "Features cannot exceed 100 characters.")]

        public string? HotelFeatures { get; set; }

        [Required(ErrorMessage = "Food description is required.")]
        [StringLength(200, ErrorMessage = "Food description cannot exceed 200 characters.")]
        public string? FoodDescription { get; set; }

        public string? MealsImageName { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Meals image is required.")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif" }, ErrorMessage = "Invalid file format. Only .jpg, .jpeg, .png, and .gif are allowed.")]
        [MaxFileSize(10 * 1024 * 1024, ErrorMessage = "Maximum file size allowed is 10MB.")]
        public IFormFile? MealsImage { get; set; }

        [NotMapped]
        public string? MealsImageSrc { get; set; }

    }
}
