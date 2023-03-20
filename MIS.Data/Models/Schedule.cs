using MIS.Data.Interfaces;
using NetTopologySuite.Geometries.Utilities;

namespace MIS.Data.Models
{
    public class Schedule : IEntity
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }

        public string Title { get; set; } = null!;

        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public byte activeDays { get; set; }
        public int TimeslotDuration { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
