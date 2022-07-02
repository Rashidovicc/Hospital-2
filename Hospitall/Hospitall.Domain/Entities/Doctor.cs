using Shifoxona.ConsoleApp.Enums.DoctorsTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitall.Domain.Entities
{
    public class Doctor : Auditable
    {
        public string FullName { get; set; }
        public DoctorsTypes doctorsTypes { get; set; }
        public byte Experiance { get; set; }
        public decimal Salary { get; set; }
    }
}
