using AutoMapper;
using Microsoft.Extensions.Logging;
using MIS.Business.Interfaces;
using MIS.Business.Models.Employee;
using MIS.Data.Interfaces;
using MIS.Data.Models;

namespace MIS.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ILogger<EmployeeService> _logger;
        private readonly IMapper _mapper;
        private readonly IMisRepository _repository;

        public EmployeeService(ILogger<EmployeeService> logger, IMapper mapper, IMisRepository repository)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Employee> Create(EmloyeeModel model)
        {
            var employee = _mapper.Map<Employee>(model);

            await _repository.CreateAsync(employee);
            await _repository.SaveChangesAsync();

            return employee;
        }

        public async Task<Employee> Update(EmloyeeModel model)
        {
            var employee = await _repository.SingleAsync<Employee>(x => x.Id == model.Id);

            // map employee model field into existing in db employee instance
            _mapper.Map(model, employee);

            // Save changes in database
            await _repository.UpdateAsync(employee);
            await _repository.SaveChangesAsync();

            return employee;
        }

        public async Task<bool> Delete(Guid id)
        {
            await _repository.DeleteAsync<Employee>(id);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<Employee> Get(Guid id)
        {
            var employee = await _repository.SingleAsync<Employee>(x => x.Id == id);
            return employee;
        }

        public async Task<IEnumerable<Employee>> List(ListEmployeesRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
