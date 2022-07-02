using Shifoxona.ConsoleApp.Enums.IllnessTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitall.Domain.Entities
{
    public class MedicalR : Auditable
    {
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public IllnessTypes illnessTypes { get; set; }
        public string  Description { get; set; }
        


    }
}
