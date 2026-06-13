using CollegeManagement.API.Entities;

namespace CollegeManagement.API.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByUserName(string userName);

        Task AddUser(User user);

        Task SaveChanges();
    }
}
