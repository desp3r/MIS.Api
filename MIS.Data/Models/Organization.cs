using Microsoft.EntityFrameworkCore;
using MIS.Data.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MIS.Data.Models
{
    [Index(nameof(OrgCode), IsUnique = true)]
    public class Organization : IEntity
    {
        public Guid Id { get; set; }

        [MaxLength(200)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(10)]
        public int OrgCode { get; set; } = 0!;

        [MaxLength(50)]
        public string Country { get; set; } = null!;

        [MaxLength(50)]
        public string Region { get; set; } = null!;

        [MaxLength(50)]
        public string City { get; set; } = null!;

        [MaxLength(50)]
        public string Address { get; set; } = null!;

        [MaxLength(5)]
        public int PostalCode { get; set; } = 0!;

        public DateTime? CreatedAt { get; set; } = null!;
        public DateTime? UpdatedAt { get; set; } = null!;
    }
}
