using IT420.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT420.Data.ExpertData
{
    public class sqlExpertTypeData : IExpertQuestionTypeData
    {
        private readonly IT420DBContext db;

        public sqlExpertTypeData(IT420DBContext db)
        {
            this.db = db;
        }
        
        public void add(ExpertQuestionType newType)
        {
            db.Add(newType);
        }

        public async Task<bool> Commit()
        {
            return (await db.SaveChangesAsync()) > 0;
        }

        public IQueryable<ExpertQuestionType> GetAll()
        {
            return db.ExpertQuestionTypes;
        }

        public ExpertQuestionType GetById(int id)
        {
            return db.ExpertQuestionTypes.Find(id);
        }

        public void Update(ExpertQuestionType updatedType)
        {
            var entity = db.ExpertQuestionTypes.Attach(updatedType);
            entity.State = EntityState.Modified;
        }
    }
}
