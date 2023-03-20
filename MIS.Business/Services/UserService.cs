using AutoMapper;
using Microsoft.Extensions.Logging;
using MIS.Business.Interfaces;
using MIS.Business.Models.User;
using MIS.Data.Interfaces;
using MIS.Data.Models;
using System.Linq;


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

        public async void GetInfo(int Id)
        {

        }
        public async void CreateAppointment(Appointment appointment)
        {

        }
        public async void GetAppointment()
        {

        }
    }
}
