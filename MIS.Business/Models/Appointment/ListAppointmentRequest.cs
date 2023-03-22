using MIS.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Business.Models.Appointment
{
    public class ListAppointmentRequest
    {
        public Guid EmployeeId { get; set; } = Guid.Empty;
        public Guid PatientId { get; set; } = Guid.Empty;
        public DateTime StartTime { get; set; } 
        public DateTime EndTime { get; set; } 
        public AppointmentStatus Status { get; set; } 
    }
}
