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
using Microsoft.AspNetCore.TestHost;

namespace MIS.IntegrationTests.Base
{
    public class IntegrationTest
    {
        protected readonly HttpClient TestClient;
        protected const string DB_CONNECTION = "Server=localhost,14331;Database=Master;User Id=sa;Password=P@ssword123";

        protected IntegrationTest()
        {
            var app = GetWebApplication();
            TestClient = app.CreateClient();
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

        protected WebApplicationFactory<Program> GetWebApplication()
            => new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var options = new DbContextOptionsBuilder<MisContext>()
                                    .UseSqlServer(DB_CONNECTION)
                                    .Options;

                    services.RemoveAll(typeof(MisContext));
                    services.AddSingleton(options);
                    services.AddSingleton<MisContext>();
                });

                builder.ConfigureAppConfiguration((ctx, config) =>
                {
                    config.AddInMemoryCollection(new Dictionary<string, string>
                    {
                        { "SqlConnectionString", "Server=localhost,14331;Database=Master;User Id=sa;Password=P@ssword123" }
                    });
                });
            });
    }
}