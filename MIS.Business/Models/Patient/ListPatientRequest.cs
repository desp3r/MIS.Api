using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Business.Models.Patient
{
    public class ListPatientRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; } = string.Empty!;
        public string LastName { get; set; } = string.Empty!;
        public string MiddleName { get; set; } = string.Empty!;
        public DateTime BirthDate { get; set; }
    }
}
