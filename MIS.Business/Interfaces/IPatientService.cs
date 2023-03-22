using MIS.Business.Models.Organization;
using MIS.Business.Models.Patient;
using MIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Business.Interfaces
{
    public interface IPatientService
    {
        public Task<Patient> CreateAsync(PatientModel model);
        public Task<Patient> UpdateAsync(PatientModel model);
        public Task<bool> DeleteAsync(Guid id);
        public Task<Patient> GetAsync(Guid id);
    }
}
