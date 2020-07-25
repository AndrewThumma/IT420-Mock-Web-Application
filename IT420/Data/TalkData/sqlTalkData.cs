using IT420.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT420.Data.TalkData
{
    public class sqlTalkData : ITalkData
    {
        private readonly IT420DBContext db;

        public sqlTalkData(IT420DBContext db)
        {
            this.db = db;
        }
        
        public void Add(Talk newTalk)
        {            
            db.Add(newTalk);
        }

        public async Task<bool> Commit()
        {
            return (await db.SaveChangesAsync()) > 0;
        }

        public void Delete(Talk talk)
        {
            db.Remove(talk);
        }

        public Talk GetNewest()
        {
            return  db.Talks.OrderByDescending(t=>t.TalkId).FirstOrDefault();
        }

        public Talk GetTalkById(int talkId)
        {
            return db.Talks.Where(t => t.TalkId == talkId).Include(t => t.TalkComments).Include(t => t.TalkType).FirstOrDefault();
        }

        public IEnumerable<Talk> GetTalksByName(string searchTerm, int typeId)
        {
            if (searchTerm == null)
            {
                return db.Talks.Where(t => t.TypeId == typeId).Include(t => t.TalkComments).Include(t => t.TalkType).OrderByDescending(b => b.CreatedDate);
            }
            return db.Talks.Where(t => t.TypeId == typeId && t.Name.Contains(searchTerm)).Include(t => t.TalkComments).Include(t => t.TalkType).OrderByDescending(b => b.CreatedDate);
        }

        public IEnumerable<Talk> GetTalksByType(int typeId)
        {
            return db.Talks.Where(t => t.TypeId == typeId).OrderByDescending(b => b.CreatedDate);
        }

        public void Update(Talk updatedTalk)
        {
            var entity = db.Attach(updatedTalk);
            entity.State = EntityState.Modified;
        }
    }
}
