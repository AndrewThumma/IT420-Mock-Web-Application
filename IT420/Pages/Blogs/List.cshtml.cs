using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT420.Areas.Identity.Data;
using IT420.Core;
using IT420.Data.BlogData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace IT420.Pages.Blogs
{
    [AllowAnonymous]
    public class ListModel : PageModel
    {
        private readonly IBlogData blogData;
        private readonly IBlogTypeData typeData;
        private readonly IAccountData accountData;

        public IEnumerable<Blog> blogs { get; set; }
        public IQueryable<UserProfile> userProfiles { get; set; }
        public string blogType { get; set; }
        public string preview { get; set; }
        public int start { get; set; }
        [BindProperty(SupportsGet = true)]
        public string searchTerm { get; set; }

        [TempData]
        public string Message { get; set; }

        public ListModel(IBlogData blogData, IBlogTypeData typeData, IAccountData accountData)
        {
            this.blogData = blogData;
            this.typeData = typeData;
            this.accountData = accountData;
            start = 0;            
        }
        
        public void OnGet(int blogTypeId)
        {
            blogs = blogData.GetApproved(blogTypeId, searchTerm);
            userProfiles = accountData.GetAll();
            blogType = typeData.GetType(blogTypeId).type;
        }
    }
}