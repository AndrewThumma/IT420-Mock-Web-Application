using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Threading.Tasks;
using IT420.Areas.Identity.Data;
using IT420.Core;
using IT420.Data.BlogData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace IT420.Pages
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBlogData blogData;
        private readonly IAccountData accountData;

        [TempData]
        public string Message { get; set; }
        public IQueryable<Blog> Blogs { get; set; }
        public Blog Blog1 { get; set; }
        public Blog Blog2 { get; set; }
        public Blog Blog3 { get; set; }
        public Blog Blog4 { get; set; }
        public IQueryable<UserProfile> userProfiles { get; set; }
        public UserProfile userProfile1 { get; set; }
        public UserProfile userProfile2 { get; set; }
        public UserProfile userProfile3 { get; set; }
        public UserProfile userProfile4 { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IBlogData blogData, IAccountData accountData)
        {
            _logger = logger;
            this.blogData = blogData;
            this.accountData = accountData;
        }

        public void OnGet()
        {
            Blogs = blogData.GetAll().Where(b => b.approved == true).OrderByDescending(b => b.CreatedDate).Take(6);
            userProfiles = accountData.GetAll();
        }
    }
}
