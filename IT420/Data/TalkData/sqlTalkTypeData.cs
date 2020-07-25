using IT420.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT420.Data.TalkData
{
    public class sqlTalkTypeData : ITypeData
    {
        private readonly IT420DBContext db;

        public sqlTalkTypeData(IT420DBContext db)
        {
            this.db = db;
        }
        
        public void Add(TalkType newType)
        {
            db.Add(newType);
        }

        public async Task<bool> Commit()
        {
            return (await db.SaveChangesAsync()) > 0;
        }

        public IQueryable<TalkType> GetAll()
        {
            return db.TalkTypes;
        }

        public TalkType GetType(int id)
        {
            return db.TalkTypes.Find(id);
        }

        public void Update(TalkType updatedType)
        {
            var entity = db.Attach(updatedType);
            entity.State = EntityState.Modified;
        }
    }
}
