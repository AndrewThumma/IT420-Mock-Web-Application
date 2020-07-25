using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT420.Core;
using IT420.Data.BlogData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT420.Pages.Admin
{
    [Authorize(Policy = "IsAdmin")]
    public class ReviewBlogsModel : PageModel
    {
        private readonly IBlogData blogData;
        public IQueryable<Blog> Blogs { get; set; }
        [TempData]
        public string Message { get; set; }

        public ReviewBlogsModel(IBlogData blogData)
        {
            this.blogData = blogData;
        }
        
        public IActionResult OnGet()
        {
            if (!User.Claims.First(c => c.Type == "IsAdmin").Value.Equals("True")) return RedirectToPage("../index");
            Blogs = blogData.GetAwaitingApproval();
            return Page();
        }
    }
}
