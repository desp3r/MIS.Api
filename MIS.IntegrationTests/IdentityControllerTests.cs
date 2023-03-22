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
            User user = new RandomEntityGenerator().User;
            RegisterUserRequest request = new RegisterUserRequest
            {
                Email = user.Email,
                Phone = user.Phone,
                Password = user.Password
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

        [Fact]
        public async Task RegisterUser_Should_ReturnAlreadyExists()
        {
            //Arange
            HttpClient client = GetWebApplication().CreateClient();
            string route = ApiRoutes.Identity.Register;
            User? existing = await TestRepository.FirstOrDefaultAsync<User>(u => true);

            if (existing == default)
            {
                existing = new RandomEntityGenerator().User;
                await TestRepository.CreateAsync(existing);
                await TestRepository.SaveChangesAsync();
            }

            RegisterUserRequest request = new RegisterUserRequest
            {
                Email = existing.Email,
                Phone = existing.Phone,
                Password = existing.Password
            };

            //Act
            HttpResponseMessage responce = await client.PostAsJsonAsync(route, request);

            //Assert
            responce.StatusCode.Should().Be(HttpStatusCode.OK);
            RegisterUserResponse registerUserResponce = await responce.Content.ReadAsAsync<RegisterUserResponse>();
            registerUserResponce.Email.Should().Be(request.Email);
            registerUserResponce.Message.Should().Be("This email is already in use. Choose another!");
        }

        [Fact]
        public async Task LoginUser_Should_ReturnSuccess()
        {
            //Arange
            HttpClient client = GetWebApplication().CreateClient();
            string route = ApiRoutes.Identity.Login;
            User? existing = await TestRepository.FirstOrDefaultAsync<User>(u => true);

            if (existing == default)
            {
                existing = new RandomEntityGenerator().User;
                await TestRepository.CreateAsync(existing);
                await TestRepository.SaveChangesAsync();
            }

            var request = new LoginUserRequest
            {
                Login = string.IsNullOrEmpty(existing.Email) ? existing.Phone : existing.Email,
                Password = existing.Password
            };

            //Act
            HttpResponseMessage responce = await client.PostAsJsonAsync(route, request);

            //Assert
            responce.StatusCode.Should().Be(HttpStatusCode.OK);
            var loginUserResponce = await responce.Content.ReadAsAsync<LoginUserResponse>();
            loginUserResponce.Token.Should().Be("success"); //mock token check
        }

        [Fact]
        public async Task LoginUser_Should_ReturnErrorWrongLogin()
        {
            //Arange
            HttpClient client = GetWebApplication().CreateClient();
            string route = ApiRoutes.Identity.Login;
            var randomEntityGenerator = new RandomEntityGenerator();
            User nonExistent = randomEntityGenerator.User;

            while (await TestRepository.FirstOrDefaultAsync<User>(u =>
                    u.Email == nonExistent.Email ||
                    u.Phone == nonExistent.Phone) != default)
            {
                nonExistent = randomEntityGenerator.User; //ensure that login is wrong
            }

            var request = new LoginUserRequest
            {
                Login = string.IsNullOrEmpty(nonExistent.Email) ? nonExistent.Phone : nonExistent.Email,
                Password = nonExistent.Password
            };

            //Act
            HttpResponseMessage responce = await client.PostAsJsonAsync(route, request);

            //Assert
            responce.StatusCode.Should().Be(HttpStatusCode.OK);
            var loginUserResponce = await responce.Content.ReadAsAsync<LoginUserResponse>();
            loginUserResponce.Token.Should().Be("error"); //mock token check
        }

        [Fact]
        public async Task LoginUser_Should_ReturnErrorWrongPassword()
        {
            //Arange
            HttpClient client = GetWebApplication().CreateClient();
            string route = ApiRoutes.Identity.Login;
            User? existing = await TestRepository.FirstOrDefaultAsync<User>(u => true);

            if (existing == default)
            {
                existing = new RandomEntityGenerator().User;
                await TestRepository.CreateAsync(existing);
                await TestRepository.SaveChangesAsync();
            }

            var request = new LoginUserRequest
            {
                Login = string.IsNullOrEmpty(existing.Email) ? existing.Phone : existing.Email,
                Password = "hopefully wrong password"
            };

            //Act
            HttpResponseMessage responce = await client.PostAsJsonAsync(route, request);

            //Assert
            responce.StatusCode.Should().Be(HttpStatusCode.OK);
            var loginUserResponce = await responce.Content.ReadAsAsync<LoginUserResponse>();
            loginUserResponce.Token.Should().Be("error"); //mock token check
        }

        [Fact, TestPriority(999)]
        public async Task EnsureUsersIsEmpty()
        {
            await ClearTableAsync<User>();

            (await TestRepository.GetAllAsync<User>()).Should().BeEmpty();
        }
    }
}
