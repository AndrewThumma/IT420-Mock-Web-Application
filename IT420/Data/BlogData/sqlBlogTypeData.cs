using IT420.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IT420.Data.BlogData
{
    public class sqlBlogTypeData : IBlogTypeData
    {
        private readonly IT420DBContext db;

        public sqlBlogTypeData(IT420DBContext db)
        {
            this.db = db;
        }
        
        public BlogType Add(BlogType newType)
        {
            db.Add(newType);
            return newType;
        }

        public async Task<bool> Commit()
        {
            return (await db.SaveChangesAsync()) > 0;
        }

        public IEnumerable<BlogType> GetAll()
        {
            return db.BlogTypes;
        }

        public BlogType GetType(int typeId)
        {
            return db.BlogTypes.Find(typeId);
        }

        public BlogType Update(BlogType updatedType)
        {
            var entity = db.BlogTypes.Attach(updatedType);
            entity.State = EntityState.Modified;
            return updatedType;
        }
    }
}
