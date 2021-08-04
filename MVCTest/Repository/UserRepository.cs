using Microsoft.EntityFrameworkCore;
using MVCTest.Abstraction;
using MVCTest.Models.DBEntities;
using MVCTest.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTest.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<User>> GetUsers(string sortOrder,
            string currentFilter,
            string searchString,
            string startDate,
            string endDate,
            string email,
            int? pageNumber)
        {
            var users = from user in _context.Users
                        select user;
            if (!string.IsNullOrEmpty(searchString))
            {
                users = users.Where(user => user.LastName.Contains(searchString)
                                       || user.FirstName.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
                users = users.Where(user => user.Birthdate > Convert.ToDateTime(startDate) && user.Birthdate < Convert.ToDateTime(endDate));
            
            if (!string.IsNullOrEmpty(email))
                users = users.Where(user => user.Email == email);

            if (!string.IsNullOrEmpty(startDate))
                users = users.Where(user => user.Birthdate > Convert.ToDateTime(startDate));

            if (!string.IsNullOrEmpty(endDate))
                users = users.Where(user => user.Birthdate < Convert.ToDateTime(endDate));

            switch (sortOrder)
            {
                case "firstname_desc":
                    users = users.OrderByDescending(s => s.FirstName);
                    break;
                case "lastname_desc":
                    users = users.OrderByDescending(s => s.LastName);
                    break;
                case "email_desc":
                    users = users.OrderByDescending(s => s.Email);
                    break;
                case "phone_desc":
                    users = users.OrderByDescending(s => s.PhoneNumber);
                    break;
                case "Date":
                    users = users.OrderBy(s => s.Birthdate);
                    break;
                case "date_desc":
                    users = users.OrderByDescending(s => s.Birthdate);
                    break;
                default:
                    users = users.OrderBy(s => s.FirstName);
                    break;
            }

            int pageSize = 10;
            return await PaginatedList<User>.CreateAsync(users.AsNoTracking(), pageNumber ?? 1, pageSize);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddUser(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users
              .FirstOrDefaultAsync(m => m.Email == email);
        }
    }
}
