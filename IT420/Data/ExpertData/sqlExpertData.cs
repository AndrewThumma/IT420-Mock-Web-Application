using IT420.Areas.Identity.Data;
using IT420.Core;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT420.Data.ExpertData
{
    public class sqlExpertData : IExpertData
    {
        private readonly IT420DBContext db;
        private readonly IAccountData accountData;
        public UserProfile userProfile { get; set; }        

        public sqlExpertData(IT420DBContext db, IAccountData accountData)
        {
            this.db = db;
            this.accountData = accountData;
        }
        
        public void Add(Expert newExpert)
        {
            db.Add(newExpert);
        }

        public async Task<bool> Commit()
        {
            return (await db.SaveChangesAsync()) > 0;
        }

        public void Delete(Expert expert)
        {            
            db.Experts.Remove(expert);
        }

        public IQueryable<Expert> GetAll()
        {
            return db.Experts;
        }

        public Expert GetById(int id)
        {
            return db.Experts.Where(e=>e.id == id).Include(c=>c.Answers).FirstOrDefault();
        }

        public void Update(Expert updatedExpert)
        {
            var entity = db.Attach(updatedExpert);
            entity.State = EntityState.Modified;
        }

        public Expert GetByUserId(string id)
        {
            return db.Experts.Where(e => e.userId == id).First();
        }
    }
}
