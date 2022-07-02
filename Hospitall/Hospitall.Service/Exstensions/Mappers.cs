using Hospitall.Domain.Entities;
using Hospitall.Service.DTOs.DoctorDTOs;
using Hospitall.Service.DTOs.MedicalRDTOs;
using Hospitall.Service.DTOs.PatientDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitall.Service.Exstensions
{
    public static class Mappers
    {
        public static Patient ConvertTo(this PatientForCreation patientForCreation)
        {
            return patientForCreation is null ? null :
                new Patient()
                {
                    Address = patientForCreation.Address,
                    CreatedAt = DateTime.Now,
                    Description = patientForCreation.Description,
                    Email = patientForCreation.Email,
                    FullName = patientForCreation.FullName,
                    IllnessTypes = patientForCreation.IllnessTypes,
                    Phone = patientForCreation.Phone
                };
        }

        public static PatientViewModel ConvertTo(this Patient patient)
        {
            return patient is null ? null :
                new PatientViewModel()
                {
                    Id = patient.Id,
                    Address = patient.Address,
                    Description = patient.Description,
                    Email = patient.Email,
                    FullName = patient.FullName,
                    IllnessTypes = patient.IllnessTypes
                };
        }

        public static Doctor ConvertTo(this DoctorForCreation doctorForCreation)
        {
            return doctorForCreation is null ? null :
                new Doctor()
                {
                    FullName = doctorForCreation.FullName,
                    Experiance = doctorForCreation.Experiance,
                    doctorsTypes = doctorForCreation.doctorsTypes
                };
        }

        public static DoctorViewModel ConvertTo(this Doctor doctor)
        {
            return doctor is null ? null :
                new DoctorViewModel()
                {
                    Id = doctor.Id,
                    doctorsTypes = doctor.doctorsTypes,
                    Experiance = doctor.Experiance,
                    FullName = doctor.FullName,
                    Salary = doctor.Salary
                                    
                };
        }

        public static MedicalR ConvertTo(this MedicalRForCreation medicalRForCreation)
        {
            return medicalRForCreation is null ? null :
                new MedicalR()
                {
                    Doctor = medicalRForCreation.Doctor,
                    Patient = medicalRForCreation.Patient,
                    Description = medicalRForCreation.Description,
                    illnessTypes = medicalRForCreation.illnessTypes
                };
        }
        
        public static MedicalRViewModel ConvertTo(this MedicalR medicalR)
        {
            return medicalR is null ? null :
                new MedicalRViewModel
                {
                    Id = medicalR.Id,
                    Doctor = medicalR.Doctor,
                    Description = medicalR.Description,
                    illnessTypes = medicalR.illnessTypes,
                    Patient = medicalR.Patient

                };
        }
    }
}
