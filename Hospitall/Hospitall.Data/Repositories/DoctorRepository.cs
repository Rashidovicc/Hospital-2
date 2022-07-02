using Hospitall.Configuration;
using Hospitall.Data.IRepositories;
using Hospitall.Domain.Entities;
using System.IO;

namespace Hospitall.Data.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public sealed override string Path { get; set; }
        public sealed override long LastId { get; set; }

        public DoctorRepository()
        {
            dynamic result = ReadFromAppSettings();
            
            Path = result.Database.Doctors.Path;
            LastId = result.Database.Doctors.LastId;

        }
        
        protected override void SaveLastId()
        {
            dynamic res = ReadFromAppSettings();
            res.Database.Doctors.LastId = LastId;

            File.WriteAllText(Constants.APP_SETTINGS_PATH, res.ToString());
        }
    }
}
