using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using MIS.Business.Enums;
using MIS.Data.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MIS.Data.Models
{
    public class Employee : IEntity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public Guid OrganizationId { get; set; }

        public Guid SpecialtyId { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty!;
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty!;
        [MaxLength(50)]
        public string MiddleName { get; set; } = string.Empty!;

        public EmployeeType EmployeeType { get; set; } = 0!;

        public double WorkingExpYears { get; set; } = 0;

        public DateTime? CreatedAt { get; set; } = null!;
        public DateTime? UpdatedAt { get; set; } = null!;
    }
}
