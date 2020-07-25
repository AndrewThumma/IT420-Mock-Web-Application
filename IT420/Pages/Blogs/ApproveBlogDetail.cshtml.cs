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
    public class ApproveBlogDetailModel : PageModel
    {
        private readonly IBlogData blogData;
        
        [BindProperty]
        public Blog blog { get; set; }

        public ApproveBlogDetailModel(IBlogData blogData)
        {
            this.blogData = blogData;
        }
        
        public IActionResult OnGet(int blogId)
        {
            blog = blogData.GetById(blogId);
            if (blog == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            blog.approved = true;
            blogData.Update(blog);

            if (await blogData.Commit())
            {
                TempData["Message"] = $"Blog Approved";
                return RedirectToPage("./ApproveBlogList");
            }
            return RedirectToPage("./NotFound");
        }
    }
}
