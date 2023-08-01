using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace BigBangProject.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string? Name { get; set; }

        [StringLength(30, ErrorMessage = "Agency name cannot exceed 100 characters.")]
        public string? AgencyName { get; set; }

        [StringLength(20, ErrorMessage = "Username cannot exceed 50 characters.")]
        public string? Username { get; set; }

        public string Password { get; set; } = string.Empty;

        public string? Token { get; set; }

        [StringLength(10, ErrorMessage = "Role cannot exceed 10 characters.")]
        public string Role { get; set; } = string.Empty;

        [StringLength(25, ErrorMessage = "Email cannot exceed 25 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }

        [Range(1, 120, ErrorMessage = "Age must be between 1 and 120.")]
        public int? Age { get; set; }

        [Range(2, 25, ErrorMessage = "Years of experience cannot be negative.")]
        public int? YearsOfExperience { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public long? PhoneNumber { get; set; }

        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
        public string? Address { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public ICollection<Feedback>? Feedbacks { get; set; }
        public ICollection<Package>? Packages { get; set; }


    }
}
