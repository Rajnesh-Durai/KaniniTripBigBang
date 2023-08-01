using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigBangProject.Model
{
    public class AgentRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(20, ErrorMessage = "Name cannot exceed 20 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Agency Name is required.")]
        [StringLength(30, ErrorMessage = "Agency Name cannot exceed 30 characters.")]
        public string? AgencyName { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(20, ErrorMessage = "Username cannot exceed 20 characters.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(20, ErrorMessage = "Password cannot exceed 20 characters.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Role is required.")]
        [StringLength(10, ErrorMessage = "Role cannot exceed 10 characters.")]
        public string Role { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }

        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100.")]
        public int? Age { get; set; }

        [Range(2, 25, ErrorMessage = "Years of Experience must be a positive value.")]
        public int? YearsOfExperience { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public long? PhoneNumber { get; set; }
    }
}
