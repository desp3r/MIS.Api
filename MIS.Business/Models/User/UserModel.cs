using MIS.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Business.Models.User
{
    public class UserModel
    {
        public Guid? Id { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; } = string.Empty!;
        public string LastName { get; set; } = string.Empty!;
        public string MiddleName { get; set; } = string.Empty!;
        public string Email { get; set; } = string.Empty!;
        public string Phone { get; set; } = string.Empty!;
    }
}
