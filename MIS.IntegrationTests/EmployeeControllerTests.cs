using FluentAssertions;
using MIS.Api.Controllers.Base;
using MIS.Business.Models.Employee;
using MIS.Data.Models;
using MIS.IntegrationTests.Base;
using MIS.IntegrationTests.Infrastructure;
using System.Net;
using System.Net.Http.Json;

namespace MIS.IntegrationTests
{
    public class EmployeeControllerTests : IntegrationTest
    {
        [Fact]
        public async Task Create_Should_CreateAnEmployee()
        {
            //Arrange
            HttpClient client = GetWebApplication().CreateClient(); 
            string route = ApiRoutes.Employee.CRUD;

            var employee = new RandomEntityGenerator().Employee;

            var request = new EmployeeModel()
            {
                UserId = employee.UserId,
                OrganizationId = employee.OrganizationId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName,
                EmployeeType = employee.EmployeeType,
                WorkingExpYears = employee.WorkingExpYears,
            };

            //Act
            var responce = await client.PostAsJsonAsync(route, request);

            //Assert
            responce.StatusCode.Should().Be(HttpStatusCode.OK);
            (await TestRepository.FirstOrDefaultAsync<Employee>(e =>
                e.UserId == request.UserId &&
                e.OrganizationId == request.OrganizationId &&
                e.FirstName == request.FirstName &&
                e.MiddleName == request.MiddleName &&
                e.LastName == request.LastName &&
                e.EmployeeType == request.EmployeeType &&
                e.WorkingExpYears == request.WorkingExpYears)).Should().NotBeNull();
        }

        [Fact]
        public async Task Update_Should_UpdateAnEmployee()
        {
            //Arrange
            HttpClient client = GetWebApplication().CreateClient();
            string route = ApiRoutes.Employee.CRUD;
            var reg = new RandomEntityGenerator();

            var oldEmployee = await TestRepository.FirstOrDefaultAsync<Employee>(e => true);
            if (oldEmployee == default)
            {
                await TestRepository.CreateAsync(reg.Employee);
                await TestRepository.SaveChangesAsync();
                oldEmployee = await TestRepository.SingleAsync<Employee>(e => true);
            }

            var newEmployee = reg.Employee;
            var request = new EmployeeModel()
            {
                Id = oldEmployee.Id,
                UserId = newEmployee.UserId,
                OrganizationId = newEmployee.OrganizationId,
                FirstName = newEmployee.FirstName,
                LastName = newEmployee.LastName,
                MiddleName = newEmployee.MiddleName,
                EmployeeType = newEmployee.EmployeeType,
                WorkingExpYears = newEmployee.WorkingExpYears,
            };

            //Act
            var responce = await client.PutAsJsonAsync(route, request);

            //Assert
            responce.StatusCode.Should().Be(HttpStatusCode.OK);
            (await TestRepository.FirstOrDefaultAsync<Employee>(e =>
                e.Id == oldEmployee.Id &&
                e.UserId == request.UserId &&
                e.OrganizationId == request.OrganizationId &&
                e.FirstName == request.FirstName &&
                e.MiddleName == request.MiddleName &&
                e.LastName == request.LastName &&
                e.EmployeeType == request.EmployeeType &&
                e.WorkingExpYears == request.WorkingExpYears)).Should().NotBeNull();
        }

        [Fact]
        public async Task Delete_Should_DeleteAnEmployee()
        {
            //Arrange
            HttpClient client = GetWebApplication().CreateClient();
            string route = ApiRoutes.Employee.CRUD;

            var employee = await TestRepository.FirstOrDefaultAsync<Employee>(e => true);
            if (employee == default)
            {
                await TestRepository.CreateAsync(new RandomEntityGenerator().Employee);
                await TestRepository.SaveChangesAsync();
                employee = await TestRepository.SingleAsync<Employee>(e => true);
            }

            var request = new EmployeeModel()
            {
                Id = employee.Id
            };

            //Act
            var responce = await client.DeleteAsync(route + "/" + employee.Id);

            //Assert
            responce.StatusCode.Should().Be(HttpStatusCode.OK);
            (await TestRepository.FirstOrDefaultAsync<Employee>(e =>
                e.Id == employee.Id)).Should().BeNull();
        }

        [Fact]
        public async Task Get_Should_ReturnAnEmployee()
        {
            //Arrange
            HttpClient client = GetWebApplication().CreateClient();
            string route = ApiRoutes.Employee.CRUD;

            var employee = await TestRepository.FirstOrDefaultAsync<Employee>(e => true);
            if (employee == default)
            {
                await TestRepository.CreateAsync(new RandomEntityGenerator().Employee);
                await TestRepository.SaveChangesAsync();
                employee = await TestRepository.SingleAsync<Employee>(e => true);
            }

            var request = new EmployeeModel()
            {
                Id = employee.Id
            };

            //Act
            var responce = await client.GetAsync(route + "/" + employee.Id);

            //Assert
            responce.StatusCode.Should().Be(HttpStatusCode.OK);
            var result = await responce.Content.ReadAsAsync<Employee>();
            result.Equals(employee).Should().BeTrue();
        }

        [Fact]
        public async Task List_Should_ReturnAllEmployees()
        {
            //Arrange
            HttpClient client = GetWebApplication().CreateClient();
            string route = ApiRoutes.Employee.List;
            var reg = new RandomEntityGenerator();

            await TestRepository.CreateAsync(reg.Employee);//add some employees
            await TestRepository.CreateAsync(reg.Employee);
            await TestRepository.CreateAsync(reg.Employee);
            await TestRepository.SaveChangesAsync();

            var employees = await TestRepository.GetAllAsync<Employee>();

            //Act
            var responce = await client.GetAsync(route);

            //Assert
            responce.StatusCode.Should().Be(HttpStatusCode.OK);
            var result = await responce.Content.ReadAsAsync<IEnumerable<Employee>>();
        }
    }
}
