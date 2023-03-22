using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Business.Models.Organization
{
    public class ListOrganizationRequest
    {
        public string Title { get; set; } = null!;
        public int OrgCode { get; set; } = 0!;
        public string Country { get; set; } = null!;
        public string Region { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int PostalCode { get; set; } = 0!;
    }
}
