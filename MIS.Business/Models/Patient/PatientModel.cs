using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Business.Models.Patient
{
    public class PatientModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; } = string.Empty!;
        public string LastName { get; set; } = string.Empty!;
        public string MiddleName { get; set; } = string.Empty!;
        public DateTime BirthDate { get; set; }
        public DateTime? CreatedAt { get; set; } = null!;
        public DateTime? UpdatedAt { get; set; } = null!;
    }
}
