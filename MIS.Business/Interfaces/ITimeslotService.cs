using MIS.Business.Models.Speciality;
using MIS.Business.Models.Timeslot;
using MIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Business.Interfaces
{
    public interface ITimeslotService
    {
        public Task<Timeslot> CreateAsync(TimeslotModel model);
        public Task<Timeslot> UpdateAsync(TimeslotModel model);
        public Task<bool> DeleteAsync(Guid id);
        public Task<Timeslot> GetAsync(Guid id);
    }
}
