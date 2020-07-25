using IT420.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT420.Data.ExpertData
{
    public interface IExpertData
    {
        IQueryable<Expert> GetAll();
        Expert GetById(int id);
        Expert GetByUserId(string id);        
        void Add(Expert newExpert);
        void Update(Expert updatedExpert);
        void Delete(Expert expert);
        Task<bool> Commit();
    }
}
