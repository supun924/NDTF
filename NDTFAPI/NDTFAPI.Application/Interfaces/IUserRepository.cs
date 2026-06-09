using NDTFAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);

        Task<User?> GetByUsernameAsync(string username);

        Task<List<User>> SearchAsync(string? search, int pageNumber, int pageSize);

        Task AddAsync(User user);

        void Update(User user);

        void Delete(User user);
    }
}
