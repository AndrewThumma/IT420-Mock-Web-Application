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
    public class UpdateBlogModel : PageModel
    {
        private readonly IBlogData blogData;

        [BindProperty]
        public Blog Blog { get; set; }

        public UpdateBlogModel(IBlogData blogData)
        {
            this.blogData = blogData;
        }
        
        public IActionResult OnGet(int blogId)
        {
            Blog = blogData.GetById(blogId);
            if (Blog == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            blogData.Update(Blog);
            blogData.Commit();
            return RedirectToPage("./Detail", new { blogId = Blog.blogId });
        }
    }
}