using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StockManagementSystem.DomainModels;
using StockManagementSystem.Infrastructure;

namespace StockManagementSystem.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _usermanager;
        public UsersController(IUserManager userManager)
        {
            _usermanager = userManager;
        }
        [HttpPost]
        [Route("/Add")]
        public StockManagementResponse<AppUser> AddUser([FromBody] AppUser user)
        {
            if (user == null) // ModelState validation
            {
                return new StockManagementResponse<AppUser>() { errorMessage = ModelState.ToString() };  // Return validation errors
            }
            var result = _usermanager.RegisterUserAsync(user);
            return new StockManagementResponse<AppUser>() { ResultData = result, isSuccessful = true, errorMessage = " " };
        }

        [HttpPut]
        [Route("/updateUsers")]
        public async Task<AppUser> UpdateUser([FromBody] AppUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var result = await _usermanager.UpdateUserAsync(user);
            return result;
        }
        [HttpGet]
        [Route("/allUsers")]
        public List<AppUser> GetAllProductsAsync()
        {
            var result = _usermanager.GetAllUsersAsync();
            if (result.Count < 1)
            {
                List<AppUser> nullresult = new List<AppUser>();

                nullresult.Add(new AppUser() { Id = -4 });
                return nullresult;
            }
            return result;
        }
        [HttpGet]
        [Route("[controller]/{id:int}")]
        public async Task<AppUser> GetUser(int id)
        {
            var result = await _usermanager.GetUserById(id);
            if (result == null)
            {
                AppUser nullresult = new AppUser() { Id = -4 };
                return nullresult;
            }
            return result;
        }
    }
}
