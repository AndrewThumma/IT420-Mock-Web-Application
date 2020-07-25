using IT420.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT420.Data.TalkData
{
    public class sqlTalkCommentData : ITalkCommentData
    {
        private readonly IT420DBContext db;

        public sqlTalkCommentData(IT420DBContext db)
        {
            this.db = db;
        }
        
        public void Add(TalkComment newComment)
        {
            db.Add(newComment);
        }

        public async Task<bool> Commit()
        {
            return (await db.SaveChangesAsync()) > 0;
        }

        public void Delete(TalkComment comment)
        {
            db.Remove(comment);
        }

        public IEnumerable<TalkComment> GetAll(int talkId)
        {
            return db.TalkComments.Where(c => c.TalkId == talkId);
        }

        public TalkComment GetById(int commentId)
        {
            return db.TalkComments.Find(commentId);
        }

        public void Update(TalkComment updatedComment)
        {
            var entity = db.Attach(updatedComment);
            entity.State = EntityState.Modified;
        }
    }
}
