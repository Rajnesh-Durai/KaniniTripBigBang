using BigBangProject.Model.DTO;

namespace BigBangProject.Services.AuthService
{
    public interface ITokenGenerateService
    {
        public string GenerateToken(UserDTO user);
    }
}
