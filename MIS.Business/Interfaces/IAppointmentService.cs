using MIS.Business.Models.Appointment;
using MIS.Business.Models.Employee;
using MIS.Business.Models.User;
using MIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Business.Interfaces
{
    public interface IAppointmentService
    {
        public Task<Appointment> CreateAsync(AppointmentModel model);
        public Task<Appointment> UpdateAsync(AppointmentModel model);
        public Task<bool> DeleteAsync(Guid id);
        public Task<Appointment> GetAsync(Guid id);
    }
}
