using IT420.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IT420.Data.BlogData
{
    public class sqlBlogData : IBlogData
    {
        private readonly IT420DBContext db;

        public sqlBlogData(IT420DBContext db)
        {
            this.db = db;
        }

        public void Add(Blog newBlog)
        {
            newBlog.CreatedDate = DateTime.Now;            
            db.Add(newBlog);
        }

        public async Task<bool> Commit()
        {
            return (await db.SaveChangesAsync()) > 0;
        }

        public void Delete(Blog blog)
        {
            db.Remove(blog);
        }

        public IQueryable<Blog> GetAll()
        {
            return db.Blogs.Include(b => b.type);
        }

        public IQueryable<Blog> GetApproved(int typeId, string searchTerm)
        {
            if (searchTerm == null)
            {
                return db.Blogs.Where(b => b.approved == true && b.blogTypeId == typeId).Include(b => b.type).OrderByDescending(b => b.CreatedDate);
            }
            return db.Blogs.Where(b => b.approved == true && b.blogTypeId == typeId && b.name.Contains(searchTerm)).Include(b => b.type).OrderByDescending(b => b.CreatedDate);
        }

        public IQueryable<Blog> GetAwaitingApproval()
        {
            return db.Blogs.Where(b => b.approved == false).Include(b => b.type);
        }

        public Blog GetById(int blogId)
        {
            return db.Blogs.Where(b => b.blogId == blogId).Include(b => b.type).FirstOrDefault();
        }

        public void Update(Blog updatedBlog)
        {
            var blog = db.Blogs.Attach(updatedBlog);
            blog.State = EntityState.Modified;
            //return updatedBlog;

        }
    }
}
