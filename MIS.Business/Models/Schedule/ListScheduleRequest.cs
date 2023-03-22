using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Business.Models.Schedule
{
    public class ListScheduleRequest
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string Title { get; set; } = null!;
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public byte activeDays { get; set; }
        public int TimeslotDuration { get; set; }
    }
}
