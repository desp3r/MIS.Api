using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Business.Models.Speciality
{
    public class ListSpecialityRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Code { get; set; } = null!;
    }
}
