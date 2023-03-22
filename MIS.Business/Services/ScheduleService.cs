using AutoMapper;
using Microsoft.Extensions.Logging;
using MIS.Business.Interfaces;
using MIS.Business.Models.Patient;
using MIS.Business.Models.Schedule;
using MIS.Data.Interfaces;
using MIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Business.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly ILogger<ScheduleService> _logger;
        private readonly IMapper _mapper;
        private readonly IMisRepository _repository;

        public ScheduleService(ILogger<ScheduleService> logger, IMapper mapper, IMisRepository repository)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Schedule> CreateAsync(ScheduleModel model)
        {
            var schedule = _mapper.Map<Schedule>(model);

            await _repository.CreateAsync(schedule);
            await _repository.SaveChangesAsync();

            return schedule;
        }

        public async Task<Schedule> UpdateAsync(ScheduleModel model)
        {
            var schedule = await _repository.SingleAsync<Schedule>(x => x.Id == model.Id);

            _mapper.Map(model, schedule);

            // Save changes in database
            await _repository.UpdateAsync(schedule);
            await _repository.SaveChangesAsync();

            return schedule;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync<Schedule>(id);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<Schedule> GetAsync(Guid id)
        {
            var schedule = await _repository.SingleAsync<Schedule>(x => x.Id == id);
            return schedule;
        }
    }
}
