using MIS.Business.Enums;
using System.ComponentModel.DataAnnotations;

namespace MIS.Business.Models.Employee
{
    public class EmployeeModel
    {
        public Guid? Id { get; set; }
        public Guid UserId { get; set; }
        public Guid OrganizationId { get; set; }
        public string FirstName { get; set; } = string.Empty!;
        public string LastName { get; set; } = string.Empty!;
        public string MiddleName { get; set; } = string.Empty!;
        public EmployeeType EmployeeType { get; set; } = 0!;
        public double WorkingExpYears { get; set; } = 0;
    }
}
