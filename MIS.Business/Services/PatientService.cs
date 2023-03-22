using AutoMapper;
using Microsoft.Extensions.Logging;
using MIS.Business.Interfaces;
using MIS.Business.Models.Organization;
using MIS.Business.Models.Patient;
using MIS.Data.Interfaces;
using MIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Business.Services
{
    public class PatientService : IPatientService
    {
        private readonly ILogger<PatientService> _logger;
        private readonly IMapper _mapper;
        private readonly IMisRepository _repository;

        public PatientService(ILogger<PatientService> logger, IMapper mapper, IMisRepository repository)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Patient> CreateAsync(PatientModel model)
        {
            var patient = _mapper.Map<Patient>(model);

            await _repository.CreateAsync(patient);
            await _repository.SaveChangesAsync();

            return patient;
        }

        public async Task<Patient> UpdateAsync(PatientModel model)
        {
            var patient = await _repository.SingleAsync<Patient>(x => x.Id == model.Id);

            _mapper.Map(model, patient);

            // Save changes in database
            await _repository.UpdateAsync(patient);
            await _repository.SaveChangesAsync();

            return patient;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync<Patient>(id);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<Patient> GetAsync(Guid id)
        {
            var patient = await _repository.SingleAsync<Patient>(x => x.Id == id);
            return patient;
        }
    }
}
