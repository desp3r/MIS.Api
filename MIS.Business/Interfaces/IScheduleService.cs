using MIS.Business.Models.Patient;
using MIS.Business.Models.Schedule;
using MIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Business.Interfaces
{
    public interface IScheduleService
    {
        public Task<Schedule> CreateAsync(ScheduleModel model);
        public Task<Schedule> UpdateAsync(ScheduleModel model);
        public Task<bool> DeleteAsync(Guid id);
        public Task<Schedule> GetAsync(Guid id);
    }
}
