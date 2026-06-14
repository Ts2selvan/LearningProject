using CollegeManagement.API.Common;
using CollegeManagement.API.DTOs;
using CollegeManagement.API.Entities;
using CollegeManagement.API.Repository.Interfaces;
using CollegeManagement.API.Services.Interfaces;

namespace CollegeManagement.API.Services
{
    public class CollegeService: ICollegeService
    {
        private readonly ICollegeRepository _repository;

        public CollegeService(ICollegeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<College>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<College> GetById(int id)
        {
            var college =
                await _repository.GetById(id);

            if (college == null)
                throw new CustomException(
                    "College Not Found");

            return college;
        }

        public async Task Add(CollegeDto dto)
        {
            var college = new College
            {
                CollegeName = dto.CollegeName,
                City = dto.City,
                StateName = dto.StateName
            };

            await _repository.Add(college);

            await _repository.SaveChanges();
        }

        public async Task Update(
            int id,
            CollegeDto dto)
        {
            var college =
                await _repository.GetById(id);

            if (college == null)
                throw new CustomException(
                    "College Not Found");

            college.CollegeName = dto.CollegeName;
            college.City = dto.City;
            college.StateName = dto.StateName;

            _repository.Update(college);

            await _repository.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var college =
                await _repository.GetById(id);

            if (college == null)
                throw new CustomException(
                    "College Not Found");

            _repository.Delete(college);

            await _repository.SaveChanges();
        }
    }
}
