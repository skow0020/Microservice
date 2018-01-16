using RestEase;
using Services.Users;
using Services.Users.Models;
using Shouldly;
using System.Net;
using Xunit;
using Services.Tests.Data;

namespace Services.Tests.UsersTests
{
    [Trait("Users", "Get Single User")]
    public class GetUser
    {
        private readonly IUsersService _githubService;

        public GetUser()
        {
            _githubService = RestClient.For<IUsersService>("https://api.github.com");
        }

        [Fact]
        public void GettingUser_ByUserId_ReturnsExpectedUser200()
        {
            TestData data = new TestData("canton7");
            User _expectedUser = data.LoadTestData("canton7");
            var response = _githubService.GetUserById("canton7").Result;
            var actualUser = response.GetContent();

            this.ShouldSatisfyAllConditions(
                () => actualUser.Name.ShouldBe(_expectedUser.Name),
                () => actualUser.Id.ShouldBe(_expectedUser.Id),
                () => actualUser.Location.ShouldBe(_expectedUser.Location),
                () => actualUser.Blog.ShouldBe(_expectedUser.Blog),
                () => actualUser.Avatar_url.ShouldBe(_expectedUser.Avatar_url),
                () => actualUser.Login.ShouldBe(_expectedUser.Login),
                () => actualUser.ShouldBe(_expectedUser),
                () => response.ResponseMessage.StatusCode.ShouldBe(HttpStatusCode.OK)
            );
        }

        [Fact]
        public void GettingUser_ByInvalidUserId_ReturnsNoData404()
        {
            var response = _githubService.GetUserById("IncorrectUser123").Result;

            this.ShouldSatisfyAllConditions(
                () => response.ResponseMessage.StatusCode.ShouldBe(HttpStatusCode.NotFound),
                () => response.GetContent().Id.ShouldBe(0)
            );
        }
    }
}
