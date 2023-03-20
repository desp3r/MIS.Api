using MIS.Data.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MIS.Data.Models
{
    public class Specialty : IEntity
    {
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; } = null!;
        [MaxLength(100)]
        public string Code { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
