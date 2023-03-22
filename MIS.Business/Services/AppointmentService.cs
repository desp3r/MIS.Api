using AutoMapper;
using Microsoft.Extensions.Logging;
using MIS.Business.Interfaces;
using MIS.Business.Models.Appointment;
using MIS.Business.Models.Employee;
using MIS.Data.Interfaces;
using MIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Business.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ILogger<AppointmentService> _logger;
        private readonly IMapper _mapper;
        private readonly IMisRepository _repository;

        public AppointmentService(ILogger<AppointmentService> logger, IMapper mapper, IMisRepository repository)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Appointment> CreateAsync(AppointmentModel model)
        {
            var appointment = _mapper.Map<Appointment>(model);

            await _repository.CreateAsync(appointment);
            await _repository.SaveChangesAsync();

            return appointment;
        }

        public async Task<Appointment> UpdateAsync(AppointmentModel model)
        {
            var appointment = await _repository.SingleAsync<Appointment>(x => x.Id == model.Id);

            _mapper.Map(model, appointment);

            // Save changes in database
            await _repository.UpdateAsync(appointment);
            await _repository.SaveChangesAsync();

            return appointment;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync<Appointment>(id);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<Appointment> GetAsync(Guid id)
        {
            var appointment = await _repository.SingleAsync<Appointment>(x => x.Id == id);
            return appointment;
        }

    }
}
