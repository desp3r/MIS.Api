using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Business.Models.Organization
{
    public class OrganizationModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public int OrgCode { get; set; } = 0!;
        public string Country { get; set; } = null!;
        public string Region { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int PostalCode { get; set; } = 0!;
        public DateTime? CreatedAt { get; set; } = null!;
        public DateTime? UpdatedAt { get; set; } = null!;
    }
}
