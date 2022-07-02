using Hospitall.Configuration;
using Hospitall.Data.IRepositories;
using Hospitall.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Hospitall.Data.Repositories
{
    public abstract class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : Auditable
    {
        public abstract string Path { get; set; }
        public abstract long LastId { get; set; }

        
        public TSource Create(TSource source)
        {
            source.Id = ++LastId;
            source.CreatedAt = DateTime.Now;

            File.WriteAllText(Path, JsonConvert.SerializeObject(GetAll().Append(source), Formatting.Indented));
            SaveLastId();
            
            return source;
        }

        public bool Delete(long id)
        {
            if (Get(p => p.Id == id) is null)
                return false;
            
            File.WriteAllText(Path, JsonConvert.SerializeObject(GetAll().Where(p => p.Id != id), Formatting.Indented));
            return true;
        }

        public TSource Get(Func<TSource, bool> predicate)
            => GetAll().FirstOrDefault(predicate);

        public IEnumerable<TSource> GetAll(Func<TSource, bool> predicate = null)
        {
            if (!File.Exists(Path)) File.WriteAllText(Path,"[]");
            
            var json = File.ReadAllText(Path);
            
            if (string.IsNullOrEmpty(json))
            {
                File.WriteAllText(Path, "[]");
                json = "[]";
            }
            
            if (predicate is null)
                return JsonConvert.DeserializeObject<IEnumerable<TSource>>(json);
            
            return JsonConvert.DeserializeObject<List<TSource>>(json)!.Where(predicate);
        }

        public TSource Update(long id, TSource source)
        {
            source.UpdatedAt = DateTime.Now;
            source.Id = id;

            File.WriteAllText(Path, JsonConvert.SerializeObject(GetAll().Select(p => p.Id == id ? source : p), Formatting.Indented));
            return source;
        }

        protected abstract void SaveLastId();
        
        protected dynamic ReadFromAppSettings()
            => JsonConvert.DeserializeObject<dynamic>( File.ReadAllText(Constants.APP_SETTINGS_PATH) );
    }
}

