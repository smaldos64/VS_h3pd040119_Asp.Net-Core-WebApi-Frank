using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Net_Core_WebApi_Frank.Models.Repository;
using Asp.Net_Core_WebApi_Frank.Models;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_Core_WebApi_Frank.Models.DataManager
{
    public class CategoryDataManager : IDataRepository<Category>
    {
        readonly DatabaseContext _databaseContext;
        
        public CategoryDataManager(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await this._databaseContext.Categories.Include(x => x.Products).ToListAsync();
        }

        //TEntity Get(long id)
        //{

        //}
       
        //void Add(TEntity entity)
        //{

        //}

        //void Update(TEntity entityToUpdate, TEntity entity)
        //{

        //}

        //void Delete(TEntity entity)
        //{

        //}
    }
}
