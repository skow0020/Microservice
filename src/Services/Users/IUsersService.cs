using RestEase;
using Services.Users.Models;
using System.Threading.Tasks;

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
        Task<Response<User>> GetUserFollowersById([Path] string userId);

        [Get("users/{userId}/following")]
        Task<Response<User>> GetUserFollowingById([Path] string userId);

    }
}