using IT420.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT420.Data.ExpertData
{
    public interface IExpertQuestionTypeData
    {
        IQueryable<ExpertQuestionType> GetAll();
        ExpertQuestionType GetById(int id);
        void Update(ExpertQuestionType updatedType);
        void add(ExpertQuestionType newType);
        Task<bool> Commit();
    }
}
