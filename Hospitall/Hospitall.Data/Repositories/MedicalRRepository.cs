using Hospitall.Configuration;
using Hospitall.Data.IRepositories;
using Hospitall.Domain.Entities;
using System.IO;
namespace Hospitall.Data.Repositories
{
    public class MedicalRRepository : GenericRepository<MedicalR>, IMedicalRRepository
    {
        public sealed override string Path { get; set; }
        public sealed override long LastId { get; set; }
        public MedicalRRepository()
        {
            dynamic result = ReadFromAppSettings();

            Path = result.Database.MedicalRs.Path;
            LastId = result.Database.MedicalRs.LastId;
        }
        protected override void SaveLastId()
        {
            dynamic tes = ReadFromAppSettings();
            tes.Database.MedicalRs.LastId = LastId;

            File.WriteAllText(Constants.APP_SETTINGS_PATH, tes.ToString());
        }
    }
}
