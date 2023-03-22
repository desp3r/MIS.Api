using MIS.Business.Models.Schedule;
using MIS.Business.Models.Speciality;
using MIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Business.Interfaces
{
    public interface ISpecialityService
    {
        public Task<Specialty> CreateAsync(SpecialityModel model);
        public Task<Specialty> UpdateAsync(SpecialityModel model);
        public Task<bool> DeleteAsync(Guid id);
        public Task<Specialty> GetAsync(Guid id);
    }
}
