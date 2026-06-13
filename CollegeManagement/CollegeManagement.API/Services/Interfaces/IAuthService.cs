using CollegeManagement.API.DTOs;

namespace CollegeManagement.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task Register(RegisterDto dto);

        Task<string> Login(LoginDto dto);
    }
}
