using AutoMapper;
using Microsoft.Extensions.Logging;
using MIS.Business.Interfaces;
using MIS.Business.Models.User;
using MIS.Data.Interfaces;
using MIS.Data.Models;
using System.Linq;


namespace MIS.Business.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly ILogger<IdentityService> _logger;
        private readonly IMapper _mapper;
        private readonly IMisRepository _repository;

        public IdentityService(ILogger<IdentityService> logger, IMapper mapper, IMisRepository repository)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<LoginUserResponse> LoginUserAsync(LoginUserRequest request)
        {
            // Get user by email and password
            var user = await _repository.FirstOrDefaultAsync<User>(user => 
                (user.Email == request.Login || user.Phone == request.Login) && 
                user.Password == request.Password);

            // If user => return mock success token
            if (user != default)
            {
                _logger.LogInformation("User has been successfully athorized");
                return new LoginUserResponse { Token = "success" };
            }

            // else => return mock error token
            _logger.LogWarning("Failed to authorize user");
            return new LoginUserResponse { Token = "error" };
        }

        public async Task<RegisterUserResponse> RegisterUserAsync(RegisterUserRequest request)
        {
            var response = _mapper.Map<RegisterUserResponse>(request);

            // Check if entered email or phone is already in use
            var user = await _repository.FirstOrDefaultAsync<User>(user => 
                user.Email == request.Email || user.Phone == request.Phone);

            // If so, return from this method with info messsage for user
            if (user != default)
            {
                response.Message = "This email is already in use. Choose another!";
                return response;
            }

            // Add user to database
            user = _mapper.Map<User>(request);
            await _repository.CreateAsync(user);
            await _repository.SaveChangesAsync();

            // return response aboud successful registrations
            response.Message = "Сongratulations you have successfully registered in the system";
            return response;
        }
    }
}
