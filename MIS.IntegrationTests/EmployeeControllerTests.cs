using FluentAssertions;
using MIS.Api.Controllers.Base;
using MIS.Business.Models.Employee;
using MIS.IntegrationTests.Infrastructure;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIS.Data.Models;
using Microsoft.AspNetCore.Mvc;
using MIS.Business.Extensions;

namespace MIS.IntegrationTests
{
    public class EmployeeControllerTests : Base.IntegrationTest
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
            var responce = await client.DeleteAsJsonAsync(route, request);

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
    }
}
