using IT420.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT420.Data.TalkData
{
    public interface ITypeData
    {
        IQueryable<TalkType> GetAll();
        TalkType GetType(int id);
        void Add(TalkType newType);
        void Update(TalkType updatedType);
        Task<bool> Commit();
    }
}
