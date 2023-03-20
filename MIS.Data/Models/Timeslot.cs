using MIS.Data.Interfaces;

namespace MIS.Data.Models
{
    public class Timeslot : IEntity
    {
        public Guid Id { get; set; }

        public Guid ScheduleId { get; set; }
        public Guid? AppointmentId { get; set; }

        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
