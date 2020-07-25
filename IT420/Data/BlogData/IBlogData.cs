using IT420.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT420.Data.BlogData
{
    public interface IBlogData
    {
        IQueryable<Blog> GetAll();
        IQueryable<Blog> GetApproved(int typeId, string searchTerm);
        IQueryable<Blog> GetAwaitingApproval();
        Blog GetById(int blogId);
        void Add(Blog newBlog);
        void Update(Blog updatedBlog);
        void Delete(Blog blog);
        Task<bool> Commit();
    }
}
