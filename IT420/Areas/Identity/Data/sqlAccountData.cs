using IT420.Core;
using IT420.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT420.Areas.Identity.Data
{
    public class sqlAccountData : IAccountData
    {
        private readonly IT420IdentityContext db;

        public sqlAccountData(IT420IdentityContext db)
        {
            this.db = db;
        }

        public async Task<bool> Commit()
        {
            return (await db.SaveChangesAsync()) > 0;
        }

        public IQueryable<UserProfile> GetAll()
        {
            return db.Users;
        }

        public UserProfile GetById(string id)
        {
            return db.Users.Find(id);
        }

        public IQueryable<UserProfile> GetNonExperts()
        {
            return db.Users.Where(u=>u.IsExpert==false);
        }

        public void Update(UserProfile userProfile)
        {
            var entity = db.Attach(userProfile);
            entity.State = EntityState.Modified;
        }
    }
}
