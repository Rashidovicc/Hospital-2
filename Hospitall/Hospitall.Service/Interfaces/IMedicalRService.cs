using Hospitall.Domain.Entities;
using Hospitall.Service.DTOs.MedicalRDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitall.Service.Interfaces
{
    public interface IMedicalRService
    {

        IEnumerable<MedicalRViewModel> GetAll(Func<MedicalR, bool> predicate = null);
        IEnumerable<MedicalRViewModel> GetAll(int page, int pageSize, Func<MedicalR, bool> predicate = null);
        MedicalRViewModel Create(MedicalRForCreation medicalForCreation);
        MedicalRViewModel Get(Func<MedicalR, bool> predicate);
        bool Delete(long id);
        MedicalRViewModel Update(long id, MedicalRForCreation doctorForCreation);


    }
}
