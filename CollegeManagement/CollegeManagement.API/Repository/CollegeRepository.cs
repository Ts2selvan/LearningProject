using CollegeManagement.API.Data;
using CollegeManagement.API.Entities;
using CollegeManagement.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace CollegeManagement.API.Repository
{
    public class CollegeRepository: ICollegeRepository
    {
        private readonly CLgDbContext _context;

        public CollegeRepository(CLgDbContext context)
        {
            _context = context;
        }

        public async Task<List<College>> GetAll()
        {
            return await _context.Colleges.ToListAsync();
        }

        public async Task<College?> GetById(int id)
        {
            return await _context.Colleges
                .FirstOrDefaultAsync(x => x.CollegeId == id);
        }

        public async Task Add(College college)
        {
            await _context.Colleges.AddAsync(college);
        }

        public void Update(College college)
        {
            _context.Colleges.Update(college);
        }

        public void Delete(College college)
        {
            _context.Colleges.Remove(college);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
