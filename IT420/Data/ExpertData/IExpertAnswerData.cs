using IT420.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT420.Data.ExpertData
{
    public interface IExpertAnswerData
    {
        ExpertQuestionAnswer GetById(int id);
        void Add(ExpertQuestionAnswer newAnswer);
        void Update(ExpertQuestionAnswer updatedAnswer);
        void Delete(ExpertQuestionAnswer answer);
        Task<bool> Commit();
    }
}
