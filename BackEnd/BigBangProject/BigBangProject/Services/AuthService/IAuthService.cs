using BigBangProject.Model.DTO;

namespace BigBangProject.Services.AuthService
{
    public interface IAuthService
    {
        Task<UserDTO> Register(UserRegisterDTO userRegisterDTO);
        Task<UserDTO> Login(UserDTO userDTO);
        Task<UserDTO> Update(UserRegisterDTO user);
        Task<bool> UpdatePassword(UserDTO userDTO);
    }
}
