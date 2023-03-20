using MIS.Data.Enums;

namespace MIS.Business.Models.User
{
    public class RegisterUserRequest
    {
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Password { get; set; } = null!;
        public UserType UserType { get; set; }
    }
}
