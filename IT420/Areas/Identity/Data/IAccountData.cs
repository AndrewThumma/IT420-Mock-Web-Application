using IT420.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT420.Areas.Identity.Data
{
    public interface IAccountData
    {
        IQueryable<UserProfile> GetAll();
        IQueryable<UserProfile> GetNonExperts();
        void Update(UserProfile userProfile);
        Task<bool> Commit();
        UserProfile GetById(string id);
    }
}
