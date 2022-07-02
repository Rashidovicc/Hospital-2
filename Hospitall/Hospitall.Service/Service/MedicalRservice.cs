using Hospitall.Data.IRepositories;
using Hospitall.Domain.Entities;
using Hospitall.Service.DTOs.MedicalRDTOs;
using Hospitall.Service.Exstensions;
using Hospitall.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitall.Service.Service
{
    public class MedicalRservice : IMedicalRService
    {
        private readonly IMedicalRRepository _medicalRRepository;

        public MedicalRViewModel Create(MedicalRForCreation medicalForCreation)
            =>_medicalRRepository.Create(medicalForCreation.ConvertTo()).ConvertTo();

        public bool Delete(long id)
            => _medicalRRepository.Delete(id);

        public MedicalRViewModel Get(Func<MedicalR, bool> predicate)
               => _medicalRRepository.Get(predicate).ConvertTo();

        public IEnumerable<MedicalRViewModel> GetAll(Func<MedicalR, bool> predicate = null)
        {
            if (predicate is null)
                return _medicalRRepository.GetAll().Select(x => x.ConvertTo());

            return _medicalRRepository.GetAll(predicate).Select(x => x.ConvertTo());
        }

        public IEnumerable<MedicalRViewModel> GetAll(int page, int pageSize, Func<MedicalR, bool> predicate = null)
            => GetAll(predicate).Skip(page*pageSize).Take(pageSize);

        public MedicalRViewModel Update(long id, MedicalRForCreation medicalForCreation)
        {
            var createdTime = _medicalRRepository.Get(x => x.Id == id).CreatedAt;

            var patient = medicalForCreation.ConvertTo();
            patient.CreatedAt = createdTime;

            return _medicalRRepository.Update(id, patient).ConvertTo();
        }
    }
}
