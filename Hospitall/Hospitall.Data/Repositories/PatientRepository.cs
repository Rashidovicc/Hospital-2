using Hospitall.Configuration;
using Hospitall.Data.IRepositories;
using Hospitall.Domain.Entities;
using System.IO;
namespace Hospitall.Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public sealed override string Path { get ; set ; }
        public sealed override long LastId { get ; set ; }
        public PatientRepository()
        {
            dynamic result = ReadFromAppSettings();

            Path = result.Database.Patients.Path;
            LastId = result.Database.Patients.LastId;
        }
        protected override void SaveLastId()
        {
            dynamic les = ReadFromAppSettings();
            les.Database.Patients.LastId = LastId;

            File.WriteAllText(Constants.APP_SETTINGS_PATH, les.ToString());
        }
    }
}
