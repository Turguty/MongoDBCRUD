using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using WebApplication1.Model;

namespace WebApplication1.DataLayer.Abstracts
{
    public interface IUsersService
    {
        Task<IEnumerable<Users>> GetAllUser();
        Task<Users> GetUser(string name);
        Task AddUser(Users model);
        Task<bool> UpdatePassword(Users model);
        Task<DeleteResult> RemoveUser(string name);
        Task<DeleteResult> RemoveAllUser();
    }
}
