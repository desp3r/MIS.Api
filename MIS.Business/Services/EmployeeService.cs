using AutoMapper;
using LinqKit;
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

        public async Task<Employee> CreateAsync(EmployeeModel model)
        {
            var employee = _mapper.Map<Employee>(model);

            await _repository.CreateAsync(employee);
            await _repository.SaveChangesAsync();

            return employee;
        }

        public async Task<Employee> UpdateAsync(EmployeeModel model)
        {
            var employee = await _repository.SingleAsync<Employee>(x => x.Id == model.Id);

            // map employee model field into existing in db employee instance
            _mapper.Map(model, employee);

            // Save changes in database
            await _repository.UpdateAsync(employee);
            await _repository.SaveChangesAsync();

            return employee;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync<Employee>(id);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<Employee> GetAsync(Guid id)
        {
            var employee = await _repository.SingleAsync<Employee>(x => x.Id == id);
            return employee;
        }

        public async Task<IEnumerable<Employee>> ListAsync(ListEmployeesRequest request)
        {
            var predicate = BuildEmployeePredicate(request);
            var employees = await _repository.GetAllAsync<Employee>(predicate);

            return employees;
        }

        private ExpressionStarter<Employee> BuildEmployeePredicate(ListEmployeesRequest request)
        {
            var predicate = PredicateBuilder.New<Employee>();

            if (request.FirstName != string.Empty)
            {
                predicate = predicate.And(emp => emp.FirstName.StartsWith(request.FirstName));
            }

            if (request.MiddleName != string.Empty)
            {
                predicate = predicate.And(emp => emp.MiddleName.StartsWith(request.MiddleName));
            }

            if (request.LastName != string.Empty)
            {
                predicate = predicate.And(emp => emp.LastName.StartsWith(request.LastName));
            }

            if (request.SpecialtyId != Guid.Empty)
            {
                predicate = predicate.And(emp => emp.SpecialtyId == request.SpecialtyId);
            }

            return predicate;
        }
    }
}
