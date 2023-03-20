using MIS.Business.Models.Employee;
using MIS.Data.Models;

namespace MIS.Business.Interfaces
{
    public interface IEmployeeService
    {
        public Task<Employee> Create(EmloyeeModel model);
        public Task<Employee> Update(EmloyeeModel model);
        public Task<bool> Delete(Guid id);
        public Task<Employee> Get(Guid id);
        public Task<IEnumerable<Employee>> List(ListEmployeesRequest request);
    }
}
