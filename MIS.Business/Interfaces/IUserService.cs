using MIS.Business.Models.User;

namespace MIS.Business.Interfaces
{
    public interface IIdentityService
    {
        public Task<RegisterUserResponse> RegisterUserAsync(RegisterUserRequest request);

        public Task<LoginUserResponse> LoginUserAsync(LoginUserRequest request);
    }
}
