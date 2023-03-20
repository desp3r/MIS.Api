using AutoMapper;
using Microsoft.Extensions.Logging;
using MIS.Business.Interfaces;
using MIS.Business.Models.Employee;
using MIS.Business.Models.User;
using MIS.Data.Interfaces;
using MIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Business.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;
        private readonly IMisRepository _repository;

        public UserService(ILogger<UserService> logger, IMapper mapper, IMisRepository repository)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<User> Create(UserModel model)
        {
            var user = _mapper.Map<User>(model);

            await _repository.CreateAsync(user);
            await _repository.SaveChangesAsync();

            return user;
        }

        public async Task<User> Update(UserModel model)
        {
            var user = await _repository.SingleAsync<User>(x => x.Id == model.Id);

            // map employee model field into existing in db employee instance
            _mapper.Map(model, user);

            // Save changes in database
            await _repository.UpdateAsync(user);
            await _repository.SaveChangesAsync();

            return user;
        }

        public async Task<bool> Delete(Guid id)
        {
            await _repository.DeleteAsync<User>(id);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<User> Get(Guid id)
        {
            var user = await _repository.SingleAsync<User>(x => x.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> List(ListUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
