using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace BigBangProject.Model.DTO
{
    public class UserRegisterDTO : User
    {
        [Required(ErrorMessage = "UserPassword field is required.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "UserPassword must be between 6 and 50 characters.")]
        public string UserPassword { get; set; } = string.Empty;
    }
}
