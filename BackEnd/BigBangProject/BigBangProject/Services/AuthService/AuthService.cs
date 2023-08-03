using BigBangProject.Model.DTO;
using BigBangProject.Model;
using System.Security.Cryptography;
using System.Text;
using BigBangProject.Repository.AuthRepository;

namespace BigBangProject.Services.AuthService
{
    public class AuthService:IAuthService
    {
        private readonly ICrudRepo<User, UserDTO> _userRepo;
        private readonly ITokenGenerateService _tokenService;

        public AuthService(ICrudRepo<User, UserDTO> userRepo, ITokenGenerateService tokenService)
        {
            _userRepo = userRepo;
            _tokenService = tokenService;
        }

        public async Task<UserDTO> Login(UserDTO userDTO)
        {
            UserDTO user = null;
            var userData = await _userRepo.GetValue(userDTO);
            if (userData != null)
            {
                var hmac = new HMACSHA512(userData.Hashkey);
                var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                for (int i = 0; i < userPass.Length; i++)
                {
                    if (userPass[i] != userData.Password[i])
                        return null;
                }
                user = new UserDTO();
                user.Id=userData.Id;
                user.Email=userData.Email;
                user.Username = userData.Username;
                user.Role = userData.Role;
                user.Token = _tokenService.GenerateToken(user);
            }
            return user;
        }

        public async Task<UserDTO?> Register(UserRegisterDTO registerDTO)
        {
            UserDTO? user = null;
            using (var hmac = new HMACSHA512())
            {
                registerDTO.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.UserPassword));
                registerDTO.Hashkey = hmac.Key;
                var resultUser = await _userRepo.Add(registerDTO);
                if (resultUser != null)
                {
                    user = new UserDTO();
                    user.Username = resultUser.Username;
                    user.Role = resultUser.Role;
                    user.Token = _tokenService.GenerateToken(user);
                }
            }
            return user;
        }

        public async Task<UserDTO?> Update(UserRegisterDTO user)
        {
            var users = await _userRepo.GetAll();
            User? myUser = users.SingleOrDefault(u => u.Username == user.Username);
            if (myUser != null)
            {
                myUser.Name = user.Name;
                myUser.PhoneNumber = user.PhoneNumber;
                var hmac = new HMACSHA512();
                myUser.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.UserPassword));
                myUser.Hashkey = hmac.Key;
                myUser.Role = user.Role;
                myUser.Email = user.Email;
                UserDTO userDTO = new UserDTO();
                userDTO.Username = myUser.Username;
                userDTO.Role = myUser.Role;
                userDTO.Token = _tokenService.GenerateToken(userDTO);
                var newUser = _userRepo.Update(myUser);
                if (newUser != null)
                {
                    return userDTO;
                }
                return null;
            }
            return null;
        }

        public async Task<bool> UpdatePassword(UserDTO userDTO)
        {
            User user = new User();
            var users = await _userRepo.GetAll();
            var myUser = users.SingleOrDefault(u => u.Username == userDTO.Username);
            if (myUser != null)
            {
                var hmac = new HMACSHA512();
                user.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                user.Hashkey = hmac.Key;
                user.Name = myUser.Name;
                user.Role = myUser.Role;
                user.PhoneNumber = myUser.PhoneNumber;
                user.Email = myUser.Email;
                var newUser = _userRepo.Update(user);
                if (newUser != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
