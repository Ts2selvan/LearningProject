using CollegeManagement.API.DTOs;
using CollegeManagement.API.Entities;
using CollegeManagement.API.Helpers;
using CollegeManagement.API.Repository.Interfaces;
using CollegeManagement.API.Services.Interfaces;


namespace CollegeManagement.API.Services
{
    public class AuthService: IAuthService
    {
       
            private readonly IUserRepository _userRepository;
            private readonly JwtTokenGenerator _jwt;

            public AuthService(
                IUserRepository userRepository,
                JwtTokenGenerator jwt)
            {
                _userRepository = userRepository;
                _jwt = jwt;
            }

            public async Task Register(RegisterDto dto)
            {
                var existingUser =
                    await _userRepository
                    .GetUserByUserName(dto.UserName);

                if (existingUser != null)
                    throw new Exception("User already exists");

                var user = new User
                {
                    UserName = dto.UserName,
                    Email = dto.Email,
                    PasswordHash =
                        BCrypt.Net.BCrypt.HashPassword(dto.Password),
                    Role = dto.Role
                };

                await _userRepository.AddUser(user);

                await _userRepository.SaveChanges();
            }

        public async Task<string> Login(LoginDto dto)
        {
            var user =
                await _userRepository
                .GetUserByUserName(dto.UserName);

            if (user == null)
                throw new Exception("Invalid User");

            bool valid =
                BCrypt.Net.BCrypt.Verify(
                    dto.Password,
                    user.PasswordHash);

            if (!valid)
                throw new Exception("Invalid Password");

            return _jwt.GenerateToken(user);
        }
        }
}
