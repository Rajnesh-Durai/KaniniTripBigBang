using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace BigBangProject.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? AgencyName { get; set; }
        public string? Username { get; set; }
        public string Password { get; set; } = string.Empty;
        public string? Token { get; set; }
        public string Role { get; set; } = string.Empty;
        public string? Email { get; set; }
        public int? Age { get; set; }
        public int? YearsOfExperience { get; set; }
        public long? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
        public ICollection<Feedback>? Feedbacks { get; set; }
        public ICollection<Package>? Packages { get; set; }


    }
}
