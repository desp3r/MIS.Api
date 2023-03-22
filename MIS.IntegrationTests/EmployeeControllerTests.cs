using MIS.Api.Controllers.Base;
using MIS.Business.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.IntegrationTests
{
    public class EmployeeControllerTests : Base.IntegrationTest
    {
        [Fact]
        public async Task Create_Should_CreateAnEmployee()
        {
            var client = GetWebApplication().CreateClient(); 
            string route = ApiRoutes.Employee.CRUD;
            var employee -
            var request = new EmloyeeModel()
            {
                UserId = new Guid("adasdas")
            };


        }
    }
}
