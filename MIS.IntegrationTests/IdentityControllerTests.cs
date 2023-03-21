using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using MIS.Api.Controllers.Base;
using MIS.Business.Models.User;
using MIS.Data.Interfaces;
using MIS.Data.Models;
using MIS.IntegrationTests.Base;

namespace MIS.IntegrationTests
{
    public class IdentityControllerTests : IntegrationTest
    {
        [Fact]
        public async Task RegisterUser_Should_CreateANewUser()
        {
            //Arange
            string route = ApiRoutes.Identity.Register;
            var request = new RegisterUserRequest
            {
                Email = "integration@test.net",
                Phone = "+3801234567",
                Password = "password"
            };

            //Act
            var responce = await TestClient.PostAsJsonAsync(route, request);

            //Assert
            responce.StatusCode.Should().Be(HttpStatusCode.OK);
            var registerUserResponce = await responce.Content.ReadAsAsync<RegisterUserResponse>();
            registerUserResponce.Email.Should().Be(request.Email);
            registerUserResponce.Message.Should().Be("Сongratulations you have successfully registered in the system");
            
        }
    }
}
