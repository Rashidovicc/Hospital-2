using Hospitall.Data.IRepositories;
using Hospitall.Data.Repositories;
using Hospitall.Domain.Entities;
using Hospitall.Service.DTOs.DoctorDTOs;
using Hospitall.Service.Exstensions;
using Hospitall.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitall.Service.Service
{
    public class DoctorService : IDoctorService
    {

        private readonly IDoctorRepository _doctorRepository;
        public DoctorService()
        {
            
            _doctorRepository = new DoctorRepository();
        }

        public DoctorViewModel Create(DoctorForCreation doctorForCreation)
        {
            var doctor = doctorForCreation.ConvertTo();
            doctor.Salary = (decimal)new Random().Next(1000,5000);

           return _doctorRepository.Create(doctor).ConvertTo();
        }

        public bool Delete(long id)
            => _doctorRepository.Delete(id);

        public DoctorViewModel Get(Func<Doctor, bool> predicate)
            => _doctorRepository.Get(predicate).ConvertTo();

        public IEnumerable<DoctorViewModel> GetAll(Func<Doctor, bool> predicate = null)
        {

            if (predicate is null)
                return _doctorRepository.GetAll().Select(x => x.ConvertTo());

            return _doctorRepository.GetAll(predicate).Select(x => x.ConvertTo());
        }

        public DoctorViewModel Update(long id, DoctorForCreation doctorForCreation)
        {
            var createdTime = _doctorRepository.Get(x => x.Id == id).CreatedAt;

            var patient = doctorForCreation.ConvertTo();
            patient.CreatedAt = createdTime;

            return _doctorRepository.Update(id, patient).ConvertTo();
        }
    }
}
