using MVCTest.Models;
using MVCTest.Models.DBEntities;
using MVCTest.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTest.Abstraction
{
    public interface IUserRepository
    {
        Task<PaginatedList<User>> GetUsers(string sortOrder,
            string currentFilter,
            string searchString,
            string startDate,
            string endDate,
            string email,
            int? pageNumber);
        Task<User> GetUserById(int id);
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int id);
        Task<User> GetUserByEmailAsync(string email);
    }
}
