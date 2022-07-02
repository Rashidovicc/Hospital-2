using Shifoxona.ConsoleApp.Enums.DoctorsTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitall.Service.DTOs.DoctorDTOs
{
    public class DoctorForCreation
    {
        public string FullName { get; set; }
        public DoctorsTypes doctorsTypes { get; set; }
        public byte Experiance { get; set; }


    }
}
