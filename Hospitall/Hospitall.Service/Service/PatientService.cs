using Hospitall.Data.IRepositories;
using Hospitall.Data.Repositories;
using Hospitall.Domain.Entities;
using Hospitall.Service.DTOs.PatientDTOs;
using Hospitall.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospitall.Service.Exstensions;

namespace Hospitall.Service.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;


        public PatientService()
        {
            _patientRepository = new PatientRepository();
        }

        
        public PatientViewModel Create(PatientForCreation patientForCreation)
            => _patientRepository.Create(patientForCreation.ConvertTo()).ConvertTo();      

        public bool Delete(long id)
            => _patientRepository.Delete(id);

        public PatientViewModel Get(Func<Patient, bool> predicate)
            => _patientRepository.Get(predicate).ConvertTo();

        public IEnumerable<PatientViewModel> GetAll(Func<Patient, bool> predicate = null)
        {
            if (predicate is null)
                return _patientRepository.GetAll().Select(x => x.ConvertTo());
                
            return _patientRepository.GetAll(predicate).Select(x => x.ConvertTo());
        }

        public PatientViewModel Update(long id, PatientForCreation patientForCreation)
        {
            var createdTime = _patientRepository.Get(x => x.Id == id).CreatedAt;

            var patient = patientForCreation.ConvertTo();
            patient.CreatedAt = createdTime;

            return _patientRepository.Update(id, patient).ConvertTo();
        }
    }
}
