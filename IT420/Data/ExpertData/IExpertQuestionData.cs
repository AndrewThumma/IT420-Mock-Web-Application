using IT420.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT420.Data.ExpertData
{
    public interface IExpertQuestionData
    {
        IQueryable<ExpertQuestion> GetAllByTypeId(int id);
        IQueryable<ExpertQuestion> GetAllByName(string searchTerm, int id);
        ExpertQuestion GetById(int id);
        void Add(ExpertQuestion newQuestion);
        void Update(ExpertQuestion updatedQuestion);
        void Delete(ExpertQuestion question);
        Task<bool> Commit();
    }
}
