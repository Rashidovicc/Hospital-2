using Hospitall.Domain.Entities;
using Hospitall.Service.DTOs.PatientDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitall.Service.Interfaces
{
    public interface IPatientService
    {
        IEnumerable<PatientViewModel> GetAll(Func<Patient, bool> predicate = null);
        PatientViewModel Create(PatientForCreation PatientForCreation);
        PatientViewModel Get(Func<Patient, bool> predicate);
        bool Delete(long id);
        PatientViewModel Update(long id, PatientForCreation doctorForCreation);


    }
}
