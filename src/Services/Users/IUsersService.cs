using RestEase;
using Services.Users.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Services.Users
{
    [Header("User-Agent", "RestEase")]
    [AllowAnyStatusCode]
    public interface IUsersService
    {
        // Get user by id
        [Get("users/{userId}")]
        Task<Response<User>> GetUserById([Path] string userId);

        [Get("users/{userId}/followers")]
        Task<Response<List<User>>> GetUserFollowersById([Path] string userId);

        [Get("users/{userId}/following")]
        Task<Response<List<User>>> GetUserFollowingById([Path] string userId);

    }
}