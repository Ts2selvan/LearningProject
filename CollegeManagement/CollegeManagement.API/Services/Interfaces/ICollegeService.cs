using CollegeManagement.API.DTOs;
using CollegeManagement.API.Entities;

namespace CollegeManagement.API.Services.Interfaces
{
    public interface ICollegeService
    {
        Task<List<College>> GetAll();

        Task<College> GetById(int id);

        Task Add(CollegeDto dto);

        Task Update(int id, CollegeDto dto);

        Task Delete(int id);
    }
}
