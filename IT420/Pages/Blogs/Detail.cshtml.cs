using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT420.Areas.Identity.Data;
using IT420.Core;
using IT420.Data.BlogData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT420.Pages.Blogs
{
    public class DetailModel : PageModel
    {
        private readonly IBlogData blogData;
        private readonly IAccountData accountData;

        public Blog Blog { get; set; }
        public UserProfile userProfile { get; set; }

        public DetailModel(IBlogData blogData, IAccountData accountData)
        {
            this.blogData = blogData;
            this.accountData = accountData;
        }
        
        public IActionResult OnGet(int blogId)
        {
            Blog = blogData.GetById(blogId);
            if (Blog == null)
            {
                return RedirectToPage("./NotFound");
            }

            userProfile = accountData.GetById(Blog.userId);

            return Page();
        }
    }
}