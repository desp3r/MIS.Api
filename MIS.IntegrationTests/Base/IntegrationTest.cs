using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MIS.Api.Controllers.Base;
using MIS.Business.Models.User;
using MIS.Data.Contexts;
using MIS.Data.Interfaces;
using MIS.Data.Models;
using MIS.Data.Repositories;
using System.Net.Http.Json;

namespace MIS.IntegrationTests.Base
{
    public class IntegrationTest
    {
        protected readonly HttpClient TestClient; //TestClient may be used to test authenticated user logic. Unused without JWT
        protected readonly IMisRepository TestRepository;
        protected const string DB_CONNECTION = "Server=localhost,14331;Database=Master;User Id=sa;Password=P@ssword123";

        protected IntegrationTest()
        {
            WebApplicationFactory<Program> app = GetWebApplication();
            TestRepository = app.Services.GetRequiredService<MisRepository>();
            TestClient = app.CreateClient();
        }

        protected async Task AuthenticateAsync() //unused without JWT
        {
            TestClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", await GetJwtAsync());
        }

        private async Task<string> GetJwtAsync() //unused without JWT
        {
            HttpResponseMessage responce = await TestClient.PostAsJsonAsync(ApiRoutes.Identity.Register,
                new RegisterUserRequest
                {
                    Email = "integration@test.net",
                    Phone = "+3801234567",
                    Password = "password"
                });

            RegisterUserResponse registrationResponse = await responce.Content.ReadAsAsync<RegisterUserResponse>();
            //return registrationResponse.Token;
            throw new NotImplementedException();
        }

        protected WebApplicationFactory<Program> GetWebApplication()
            => new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    DbContextOptions<MisContext> options = new DbContextOptionsBuilder<MisContext>()
                                    .UseSqlServer(DB_CONNECTION)
                                    .Options;

                    services.RemoveAll(typeof(MisContext));
                    services.AddSingleton(options);
                    services.AddSingleton<MisContext>();
                    services.AddSingleton<MisRepository>();
                });

                builder.ConfigureAppConfiguration((ctx, config) =>
                {
                    config.AddInMemoryCollection(new Dictionary<string, string>
                    {
                        { "SqlConnectionString", "Server=localhost,14331;Database=Master;User Id=sa;Password=P@ssword123" }
                    });
                });
            });

        protected async Task ClearTableAsync<T>() where T : class, IEntity
        {
            var users = await TestRepository.GetAllAsync<T>();
            foreach (var user in users)
            {
                await TestRepository.DeleteAsync<T>(user.Id);
            }

            await TestRepository.SaveChangesAsync();
        }
    }
}