using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using MIS.Data;
using System.Net.Http;
using MIS.Data.Contexts;
using System.Net.Http.Json;
using MIS.Api.Controllers.Base;
using MIS.Business.Models.User;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using MIS.Data.Interfaces;
using MIS.Data.Repositories;

namespace MIS.IntegrationTests.Base
{
    public class IntegrationTest
    {
        protected readonly HttpClient TestClient;

        protected IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(MisContext));
                        services.AddDbContext<MisContext>(options =>
                        {
                            options.UseInMemoryDatabase("TestMisDatabase");
                        });
                    });
                });

            TestClient = appFactory.CreateClient();
        }

        protected async Task AuthenticateAsync() //unused without JWT
        {
            TestClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", await GetJwtAsync());
        }

        private async Task<string> GetJwtAsync() //unused without JWT
        {
            var responce = await TestClient.PostAsJsonAsync(ApiRoutes.Identity.Register,
                new RegisterUserRequest
                {
                    Email = "integration@test.net",
                    Phone = "+3801234567",
                    Password = "password"
                });

            var registrationResponse = await responce.Content.ReadAsAsync<RegisterUserResponse>();
            //return registrationResponse.Token;
            throw new NotImplementedException();
        }
    }
}