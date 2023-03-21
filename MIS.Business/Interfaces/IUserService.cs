using MIS.Business.Models.Employee;
using MIS.Business.Models.User;
using MIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Business.Interfaces
{
    public interface IUserService
    {
        public Task<User> Create(UserModel model);
        public Task<User> Update(UserModel model);
        public Task<bool> Delete(Guid id);
        public Task<User> Get(Guid id);
        public Task<IEnumerable<User>> List(ListUserRequest request);
    }
}
