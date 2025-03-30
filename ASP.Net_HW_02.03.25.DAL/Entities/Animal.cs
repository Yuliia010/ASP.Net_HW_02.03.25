using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_HW_02._03._25.DAL.Entities
{
    public class Animal
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Sound { get; set; }

        public string? OtherInfo { get; set; }
    }
}
