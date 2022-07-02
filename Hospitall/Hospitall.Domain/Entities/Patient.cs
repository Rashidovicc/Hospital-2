using Shifoxona.ConsoleApp.Enums.IllnessTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitall.Domain.Entities
{
    public class Patient:Auditable
    {
        public string FullName { get; set; }
        public IllnessTypes IllnessTypes { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        
    }
}
