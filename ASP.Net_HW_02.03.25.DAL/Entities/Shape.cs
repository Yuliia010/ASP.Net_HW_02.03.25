using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_HW_02._03._25.DAL.Entities
{
    public class Shape
    {
        public Guid Id { get; set; }
        public string Type { get; set; } 
        public string Presentation { get; set; }
        public string? ParametersInfo { get; set; }
        public string? OtherInfo { get; set; }
    }
}
