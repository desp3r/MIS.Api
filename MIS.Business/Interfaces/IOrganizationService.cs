using MIS.Business.Models.Appointment;
using MIS.Business.Models.Organization;
using MIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Business.Interfaces
{
    public interface IOrganizationService
    {
        public Task<Organization> CreateAsync(OrganizationModel model);
        public Task<Organization> UpdateAsync(OrganizationModel model);
        public Task<bool> DeleteAsync(Guid id);
        public Task<Organization> GetAsync(Guid id);
    }
}
