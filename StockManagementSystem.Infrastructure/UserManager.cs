using Microsoft.EntityFrameworkCore;
using StockManagementSystem.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.Infrastructure
{
    public class UserManager : IUserManager
    {
        private readonly ApplicationDbContext _context;
        public UserManager(ApplicationDbContext context) {
        _context = context;
        }
       async Task<AppUser> IUserManager.DeleteUserAsync(int userId)
        {
            var usertoDelete = _context.AppUsers.Find(userId);
            if (usertoDelete == null)
            {
                return usertoDelete;
            }
            else
            {
                await _context.AppUsers.Remove(usertoDelete).ReloadAsync();
                await _context.SaveChangesAsync();
                return usertoDelete;
            }
           
        }

        List<AppUser> IUserManager.GetAllUsersAsync()
        {
            return _context.AppUsers.ToList();
        }

        async Task<AppUser?> IUserManager.GetUserById(int userId)
        {
            return await _context.AppUsers.FindAsync(userId);
        }

        async Task<AppUser?> IUserManager.GetuserByName(string uName)
        {
            return await _context.AppUsers.FirstAsync(a => a.userName == uName);
        }

        AppUser IUserManager.RegisterUser(AppUser user)
        {
        if(user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.hashedPassword = Utilities.HashPassword(user.password);
            _context.AppUsers.Add(user);
        _context.SaveChanges();
        return user;
        }

        AppUser IUserManager.RegisterUserAsync(AppUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.hashedPassword = Utilities.HashPassword(user.password);
             _context.AppUsers.Add(user);
            _context.SaveChanges();
            return user;
        }

        async Task<AppUser> IUserManager.UpdateUserAsync(AppUser user)
        {
            var existingUser = await _context.AppUsers.FirstOrDefaultAsync(a => a.userName == user.userName);
            if (existingUser == null)
            {
                return new AppUser();
            }
            existingUser.userName = user.userName;
            existingUser.Id = user.Id;
            existingUser.email = user.email;
            existingUser.password = user.password;
            existingUser.hashedPassword = Utilities.HashPassword(user.password);
            existingUser.firstName = user.firstName;
            existingUser.lastName = user.lastName;
            await _context.SaveChangesAsync();
            return existingUser;
        }
    }
}
