using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Business.Models.Speciality
{
    public class SpecialityModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Code { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
