using CollegeManagement.API.Data;
using CollegeManagement.API.Entities;
using CollegeManagement.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace CollegeManagement.API.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly CLgDbContext _context;

        public UserRepository(CLgDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

       
    }
}
