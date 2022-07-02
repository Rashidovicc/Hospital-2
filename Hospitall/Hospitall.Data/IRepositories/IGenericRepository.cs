using Hospitall.Domain.Entities;
using System;
using System.Collections.Generic;


namespace Hospitall.Data.IRepositories
{
    public interface IGenericRepository<TSource> where TSource : Auditable
    {
        TSource Create(TSource source);
        TSource Get(Func<TSource,bool> predicate);
        TSource Update(long id,TSource source);
        IEnumerable<TSource> GetAll(Func<TSource,bool> predicate = null);
        bool Delete(long id);


    }
}
