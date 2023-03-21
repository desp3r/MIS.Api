using FluentAssertions;
using MIS.Api.Controllers.Base;
using MIS.Business.Models.User;
using MIS.Data.Models;
using MIS.IntegrationTests.Base;
using MIS.IntegrationTests.Infrastructure;
using System.Net;

namespace MIS.IntegrationTests
{
    public class IdentityControllerTests : IntegrationTest
    {
        [Fact]
        public async Task RegisterUser_Should_CreateANewUser()
        {
            //Arange
            HttpClient client = GetWebApplication().CreateClient();
            string route = ApiRoutes.Identity.Register;
            RegisterUserRequest request = new RegisterUserRequest
            {
                Email = "integration@test.net",
                Phone = "+3801234567",
                Password = "password"
            };

            //Act
            HttpResponseMessage responce = await client.PostAsJsonAsync(route, request);

            //Assert
            responce.StatusCode.Should().Be(HttpStatusCode.OK);
            RegisterUserResponse registerUserResponce = await responce.Content.ReadAsAsync<RegisterUserResponse>();
            registerUserResponce.Email.Should().Be(request.Email);
            (await TestRepository.FirstOrDefaultAsync<User>(u =>
                    u.Email == request.Email &&
                    u.Phone == request.Phone &&
                    u.Password == request.Password)).Should().NotBeNull();
            registerUserResponce.Message.Should().Be("Сongratulations you have successfully registered in the system");
        }

        [Fact, TestPriority(999)]
        public async Task EnsureUsersIsEmpty()
        {
            await ClearTableAsync<User>();

            (await TestRepository.GetAllAsync<User>()).Should().BeEmpty();
        }
    }
}
