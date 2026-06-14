using CollegeManagement.API.Entities;

namespace CollegeManagement.API.Repository.Interfaces
{
    public interface ICollegeRepository
    {
        Task<List<College>> GetAll();

        Task<College?> GetById(int id);

        Task Add(College college);

        void Update(College college);

        void Delete(College college);

        Task SaveChanges();
    }
}
