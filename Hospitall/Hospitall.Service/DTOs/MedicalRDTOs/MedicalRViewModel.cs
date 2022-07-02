using Hospitall.Domain.Entities;
using Shifoxona.ConsoleApp.Enums.IllnessTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitall.Service.DTOs.MedicalRDTOs
{
    public class MedicalRViewModel
    {
        public long Id { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public IllnessTypes illnessTypes { get; set; }
        public string Description { get; set; }
    }
}
