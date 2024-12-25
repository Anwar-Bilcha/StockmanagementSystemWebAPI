using StockManagementSystem.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.Infrastructure
{
    public interface IUserManager
    {
        Task<AppUser?> GetUserById(int userId);
        Task<AppUser?> GetuserByName(string uName);
        AppUser RegisterUser(AppUser user);
        AppUser RegisterUserAsync(AppUser user);
        Task<AppUser> DeleteUserAsync(int userId);
        Task<AppUser> UpdateUserAsync(AppUser user);
        List<AppUser> GetAllUsersAsync();
    }
}
