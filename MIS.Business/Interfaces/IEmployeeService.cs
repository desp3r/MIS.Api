using MIS.Business.Models.Employee;
using MIS.Data.Models;

namespace MIS.Business.Interfaces
{
    public interface IEmployeeService
    {
        public Task<Employee> CreateAsync(EmloyeeModel model);
        public Task<Employee> UpdateAsync(EmloyeeModel model);
        public Task<bool> DeleteAsync(Guid id);
        public Task<Employee> GetAsync(Guid id);
        public Task<IEnumerable<Employee>> ListAsync(ListEmployeesRequest request);
    }
}
