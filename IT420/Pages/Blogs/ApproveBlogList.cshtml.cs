using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT420.Core;
using IT420.Data.BlogData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT420.Pages.Blogs
{
    public class ApproveBlogListModel : PageModel
    {
        private readonly IBlogData blogData;
        public IQueryable<Blog> blogs { get; set; }    
        [TempData]
        public string Message { get; set; }

        public ApproveBlogListModel(IBlogData blogData)
        {
            this.blogData = blogData;
        }
        
        public void OnGet()
        {
            blogs = blogData.GetAwaitingApproval();
        }
        
        
    }
}
