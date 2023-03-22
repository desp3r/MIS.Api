using AutoMapper;
using Microsoft.Extensions.Logging;
using MIS.Business.Interfaces;
using MIS.Business.Models.Schedule;
using MIS.Business.Models.Speciality;
using MIS.Data.Interfaces;
using MIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Business.Services
{
    public class SpecialityService : ISpecialityService
    {
        private readonly ILogger<SpecialityService> _logger;
        private readonly IMapper _mapper;
        private readonly IMisRepository _repository;

        public SpecialityService(ILogger<SpecialityService> logger, IMapper mapper, IMisRepository repository)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Specialty> CreateAsync(SpecialityModel model)
        {
            var speciality = _mapper.Map<Specialty>(model);

            await _repository.CreateAsync(speciality);
            await _repository.SaveChangesAsync();

            return speciality;
        }

        public async Task<Specialty> UpdateAsync(SpecialityModel model)
        {
            var speciality = await _repository.SingleAsync<Specialty>(x => x.Id == model.Id);

            _mapper.Map(model, speciality);

            // Save changes in database
            await _repository.UpdateAsync(speciality);
            await _repository.SaveChangesAsync();

            return speciality;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync<Specialty>(id);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<Specialty> GetAsync(Guid id)
        {
            var speciality = await _repository.SingleAsync<Specialty>(x => x.Id == id);
            return speciality;
        }
    }
}
