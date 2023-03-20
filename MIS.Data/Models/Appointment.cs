using MIS.Data.Enums;
using MIS.Data.Interfaces;

namespace MIS.Data.Models
{
    public class Appointment : IEntity
    {
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }
        public Guid PatientId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public AppointmentStatus Status { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
