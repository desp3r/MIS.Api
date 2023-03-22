using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Business.Models.Timeslot
{
    public class ListTimeslotRequest
    {
        public Guid Id { get; set; }
        public Guid ScheduleId { get; set; }
        public Guid? AppointmentId { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
    }
}
