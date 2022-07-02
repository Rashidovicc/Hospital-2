using Hospitall.Domain.Entities;
using Hospitall.Service.DTOs.DoctorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitall.Service.Interfaces
{
    public interface IDoctorService
    {
        DoctorViewModel Create(DoctorForCreation doctorForCreation);
        IEnumerable<DoctorViewModel> GetAll(Func<Doctor, bool> predicate = null);
        DoctorViewModel Get(Func<Doctor, bool> predicate);
        bool Delete(long id);
        DoctorViewModel Update(long id, DoctorForCreation doctorForCreation);


    }
}
