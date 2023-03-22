using AutoMapper;
using Microsoft.Extensions.Logging;
using MIS.Business.Interfaces;
using MIS.Business.Models.Speciality;
using MIS.Business.Models.Timeslot;
using MIS.Data.Interfaces;
using MIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Business.Services
{
    public class TimeslotService : ITimeslotService
    {
        private readonly ILogger<TimeslotService> _logger;
        private readonly IMapper _mapper;
        private readonly IMisRepository _repository;

        public TimeslotService(ILogger<TimeslotService> logger, IMapper mapper, IMisRepository repository)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Timeslot> CreateAsync(TimeslotModel model)
        {
            var timeslot = _mapper.Map<Timeslot>(model);

            await _repository.CreateAsync(timeslot);
            await _repository.SaveChangesAsync();

            return timeslot;
        }

        public async Task<Timeslot> UpdateAsync(TimeslotModel model)
        {
            var timeslot = await _repository.SingleAsync<Timeslot>(x => x.Id == model.Id);

            _mapper.Map(model, timeslot);

            // Save changes in database
            await _repository.UpdateAsync(timeslot);
            await _repository.SaveChangesAsync();

            return timeslot;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync<Timeslot>(id);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<Timeslot> GetAsync(Guid id)
        {
            var timeslot = await _repository.SingleAsync<Timeslot>(x => x.Id == id);
            return timeslot;
        }
    }
}
