using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using MIS.Api.Controllers.Base;
using MIS.Business.Models.User;
using MIS.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MIS.Api.Tests
{
    public class IdentityControllerTests
    {
        private const string _dbConntection = "Server=(localdb)\\mssqllocaldb;Database=TestDatabase;Trusted_Connection=True;";

        private WebApplicationFactory<Program> _application;

        public IdentityControllerTests()
        {
            _application = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => {
                builder.ConfigureTestServices(services => {
                    var options = new DbContextOptionsBuilder<MisContext>()
                                    .UseSqlServer(_dbConntection)
                                    .Options;

                    services.AddSingleton(options);
                    services.AddSingleton<MisContext>();
                });
            });
        }

        [Fact]
        public async Task RegisterUser_returns_200()
        {
            //Arange

            var client = _application.CreateClient();
            string route = ApiRoutes.Identity.Register;
            var request = new RegisterUserRequest
            {
                Email = "integration@test.net",
                Phone = "+3801234567",
                Password = "password"
            };

            //Act

            var responce = await client.PostAsJsonAsync(route, request);

            //Assert
            //responce.StatusCode.Should().Be(HttpStatusCode.OK);
            var registerUserResponce = await responce.Content.ReadAsAsync<RegisterUserResponse>();
            Console.WriteLine(registerUserResponce.Email);

        }
    }
}
