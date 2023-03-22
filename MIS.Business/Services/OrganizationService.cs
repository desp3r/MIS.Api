using AutoMapper;
using Microsoft.Extensions.Logging;
using MIS.Business.Interfaces;
using MIS.Business.Models.Appointment;
using MIS.Business.Models.Organization;
using MIS.Data.Interfaces;
using MIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Business.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly ILogger<OrganizationService> _logger;
        private readonly IMapper _mapper;
        private readonly IMisRepository _repository;

        public OrganizationService(ILogger<OrganizationService> logger, IMapper mapper, IMisRepository repository)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Organization> CreateAsync(OrganizationModel model)
        {
            var organization = _mapper.Map<Organization>(model);

            await _repository.CreateAsync(organization);
            await _repository.SaveChangesAsync();

            return organization;
        }

        public async Task<Organization> UpdateAsync(OrganizationModel model)
        {
            var organization = await _repository.SingleAsync<Organization>(x => x.Id == model.Id);

            _mapper.Map(model, organization);

            // Save changes in database
            await _repository.UpdateAsync(organization);
            await _repository.SaveChangesAsync();

            return organization;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync<Organization>(id);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<Organization> GetAsync(Guid id)
        {
            var organization = await _repository.SingleAsync<Organization>(x => x.Id == id);
            return organization;
        }
    }
}
