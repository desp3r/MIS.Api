using MIS.Data.Enums;
using MIS.Data.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MIS.Data.Models
{
    public class User : IEntity
    {
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string Email { get; set; } = null!;

        [MaxLength(20)]
        public string Phone { get; set; } = null!;

        [MaxLength(30)]
        public string Password { get; set; } = null!;
        public UserType UserType { get; set; }
        public bool IsVerified { get; set; } = false;

        public DateTime? CreatedAt { get; set; } = null!;
        public DateTime? UpdatedAt { get; set; } = null!;

    }
}
