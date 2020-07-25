using IT420.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace IT420.Data.ExpertData
{
    public class sqlExpertAnswerData : IExpertAnswerData
    {
        private readonly IT420DBContext db;
        private readonly IExpertQuestionData questionData;        

        public sqlExpertAnswerData(IT420DBContext db, IExpertQuestionData questionData)
        {
            this.db = db;
            this.questionData = questionData;
        }
        
        public void Add(ExpertQuestionAnswer newAnswer)
        {
            db.Add(newAnswer);
        }

        public async Task<bool> Commit()
        {
            return (await db.SaveChangesAsync()) > 0;
        }

        public void Delete(ExpertQuestionAnswer answer)
        {
            db.ExpertAnswers.Remove(answer);
        }

        public ExpertQuestionAnswer GetById(int id)
        {
            return db.ExpertAnswers.Where(a => a.id == id).Include(a => a.Question).Include(a => a.Expert).FirstOrDefault();
        }

        public void Update(ExpertQuestionAnswer updatedAnswer)
        {
            var entity = db.Attach(updatedAnswer);
            entity.State = EntityState.Modified;
        }
    }
}
