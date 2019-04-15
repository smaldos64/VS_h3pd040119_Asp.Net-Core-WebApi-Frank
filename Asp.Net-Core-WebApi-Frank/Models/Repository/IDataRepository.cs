using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Core_WebApi_Frank.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        Task <IEnumerable<TEntity>> GetAll();
        //Task <TEntity> Get(long id);
        ////TDto GetDto(long id);
        //Task Add(TEntity entity);
        //Task Update(TEntity entityToUpdate, TEntity entity);
        //Task Delete(TEntity entity);
    }
}


