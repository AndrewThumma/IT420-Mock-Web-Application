using IT420.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT420.Data.ExpertData
{
    public class sqlExpertQuestionData : IExpertQuestionData
    {
        private readonly IT420DBContext db;

        public sqlExpertQuestionData(IT420DBContext db)
        {
            this.db = db;
        }

        public void Add(ExpertQuestion newQuestion)
        {
            newQuestion.CreatedDate = DateTime.Now;            
            db.Add(newQuestion);
        }

        public async Task<bool> Commit()
        {
            return (await db.SaveChangesAsync()) > 0;
        }

        public void Delete(ExpertQuestion question)
        {
            db.Remove(question);
        }

        public IQueryable<ExpertQuestion> GetAllByName(string searchTerm, int id)
        {
            if (searchTerm == null)
            {
                return db.ExpertQuestions.Where(q => q.typeId == id).Include(q => q.Type).Include(q => q.Answer).ThenInclude(q => q.Expert);
            }
            return db.ExpertQuestions.Where(q => q.typeId == id && q.question.Contains(searchTerm)).Include(q => q.Type).Include(q => q.Answer).ThenInclude(q => q.Expert);
        }

        public IQueryable<ExpertQuestion> GetAllByTypeId(int id)
        {
            return db.ExpertQuestions.Where(q => q.typeId == id).Include(q => q.Type).Include(q => q.Answer).ThenInclude(q => q.Expert);
        }

        public ExpertQuestion GetById(int id)
        {
            return db.ExpertQuestions.Where(q=>q.id == id).Include(q=>q.Type).Include(q=>q.Answer).ThenInclude(q=>q.Expert).FirstOrDefault();
        }

        public void Update(ExpertQuestion updatedQuestion)
        {
            var entity = db.Attach(updatedQuestion);
            entity.State = EntityState.Modified;
        }
    }
}
